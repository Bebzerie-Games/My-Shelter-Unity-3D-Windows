using MyShelterWin64.Game.Economy;
using MyShelterWin64.Game.Manager;
using System;
using System.Collections;
using UnityEngine;

namespace MyShelterWin64.Game.Building {
    /// <summary>
    /// Main building component
    /// </summary>

    public class GameBuilding : GameEconomyObject
    {
        public override event Action OnEntitySpawn;
        public override event Action OnInteractionEnter;
        public override event Action OnInteractionExit;

        [SerializeField] GameBuildingHUD _buildingHUD;

        private void OnEnable() {
            OnInteractionEnter += () => {
                // increase economy based on the generated economy value per delay
                GameManager.Instance.GameEconomy.SynchronizeObjectValuesWithStats(this);
                GameManager.Instance.GameHUDCtrl.UpdateGoldValueText();
            };
        }

        public override void DoInteractionEnter() {
            OnInteractionEnter.Invoke();
        }

        public override void DoInteractionExit() {
            OnInteractionExit.Invoke();
        }

        public override IEnumerator Add() {
            SetDelay();

            while (gameObject.activeSelf) {
                _buildingHUD.EnableRessourcePopUp();

                yield return base.Add();
            }
        }
    }
}