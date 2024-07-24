using MyShelterWin64.Game.Manager;
using UnityEngine;

namespace MyShelterWin64.Game.Building {
    /// <summary>
    /// GameBuilding hud system
    /// </summary>
    public class GameBuildingHUD : MonoBehaviour {
        [SerializeField] GameObject _popUpRessource;
        [SerializeField] GameBuilding _buildingInstance;


        public void EnableRessourcePopUp() {
            _popUpRessource.SetActive(!_popUpRessource.activeSelf);
            GameManager.MS_PRINT(typeof(GameBuildingHUD), "ok display popupressource");
            HandleRessourceDisplayPopUp();
        }

        /// <summary>
        /// on click this will generate the hud popup
        /// </summary>
        public void HandleRessourceDisplayPopUp() {
            _buildingInstance.DoInteractionEnter();
        }
    }
}