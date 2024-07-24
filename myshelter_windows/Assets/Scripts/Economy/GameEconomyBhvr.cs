using MyShelterWin64.Game.Building;
using MyShelterWin64.Game.Manager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyShelterWin64.Game.Economy {
    /// <summary>
    /// generation d'economie en runtime avec delais
    /// </summary>
    public sealed class GameEconomyBhvr : MonoBehaviour {
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
            // TODO : creer le système de sauvegarde de l'economie du joueur dès que le status du developpment de jeu le permet
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