using MyShelterWin64.Building;
using MyShelterWin64.Game.Manager;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace MyShelterWin64.Economy {
    /// <summary>
    /// generation d'economie en runtime avec delais
    /// </summary>
    public class GameEconomyBhvr : MonoBehaviour {
        [Header("Value :")]
        [SerializeField] GameEconomyGoldSO _goldEconomy;
        [SerializeField] GameEconomyVitalSO _vitalEconomy;

        [Header("Building :")]
        [SerializeField] GameBuildingManager _buildingManager;

        /*
         pour le système de building il faudrait enregistrer le gameobject des placeable object ici
        et faire un getcomponent de leur script GameEconomyRuntime et appeler la fonction async respective
         
         */
        public List<GameBuilding> EconomyObjects = new();

        [Space]
        [Header("Economy Stats :")]
        public float Gold;
        public float Vital;

        private void Start() {
            List<IEnumerator> routines = new();

            foreach (var economy in _buildingManager.GameBuildingsList)  
            {
                EconomyObjects.Add(economy); // TODO : creer le système de sauvegarde de l'economie du joueur dès que le status du developpment de jeu le permet
                routines.Add(economy.Add());
            }

            foreach (var routine in routines)
                StartCoroutine(routine);
        }

        public void UpdateBuildingList(GameBuilding building) {
            EconomyObjects.Add(building); // TODO : creer le système de sauvegarde de l'economie du joueur dès que le status du developpment de jeu le permet
            StartCoroutine(building.Add());
        }

        public void SynchronizeObjectValuesWithStats(GameEconomyObject economyObject) {
            switch (economyObject.BuildingSO.EconomyGenerationType) {
                case GameEconomyObjectType.Vital:
                    Vital += economyObject.BuildingSO.GenerationPerDelay;
                    break;

                case GameEconomyObjectType.Money:
                    Gold += economyObject.BuildingSO.GenerationPerDelay;
                    break;
            }
        }
    }
}