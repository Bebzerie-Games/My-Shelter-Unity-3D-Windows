using MyShelterWin64.AI;
using MyShelterWin64.Economy;
using MyShelterWin64.Game.Manager;
using System;
using UnityEngine;
using UnityEngine.Events;

namespace MyShelterWin64.Game {
    public class Entity : MonoBehaviour {
        public EntitySO EntitySO;

        event Action OnInteractionEnter;
        event Action OnInteractionExit;
        event Action OnSpawn;

        [Header("Economy Entity :")]
        public GameEconomyObject EconomyObject = null;

        [Header("AI Entity :")]
        [SerializeField] GameObject _npcCallbacks;

        private void OnEnable() {
            if (EntitySO.Type == EntityType.Building)
                OnInteractionEnter = () => {
                    // increase economy based on the generated economy value per delay
                    GameManager.Instance.GameEconomy.SynchronizeObjectValuesWithStats(EconomyObject);
                    GameManager.Instance.PlayerHUDCtrl.UpdateGoldValueText();
                };
            else if (EntitySO.Type == EntityType.AI) {
                OnInteractionEnter = () => {
                    _npcCallbacks.SetActive(!_npcCallbacks.activeSelf);
                };
            }

            OnInteractionExit = () => { };

            OnSpawn = () => {
                GameManager.Instance.BuildingPlacement.RegisterNewBuilding();
            };
        }

        public void DoInteractionExit() {
            OnInteractionExit.Invoke();
        }

        public void DoInteractionEnter() {
            OnInteractionEnter.Invoke();
        }

        public void DoSpawn() {
            OnSpawn.Invoke();
        }
    }
}