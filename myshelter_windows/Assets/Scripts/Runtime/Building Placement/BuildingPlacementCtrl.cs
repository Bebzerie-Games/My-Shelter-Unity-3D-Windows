using MyShelterWin64.Building;
using MyShelterWin64.Game.Manager;
using MyShelterWin64.Player;
using System.Linq;
using UnityEngine;

namespace MyShelterWin64.Game.Building {
    public class BuildingPlacementCtrl : MonoBehaviour {
        [Header("Data :")]
        [SerializeField] GameObject _mouseIndicator;
        [SerializeField] GameObject _cellIndicator;
        [SerializeField] PlayerHUDCtrl _playerHud;

        [SerializeField] PlayerInputBhvr _inputBhvr;
        [SerializeField] Grid _floorGrid;

        [SerializeField] GameObject _gridVisualization;

        Entity _selectedObjectIndex;

        public string Name {
            get {
                return _name;
            }
        }

        string _name;

        public void ChangeName(string newName) {
            _name = newName;
        }

        public static bool IsInBuilderMod {
            get; set;
        }

        private void Start() {
            ShowGridVisualization(false);
            ShowCellIndicator(false);
            _playerHud.DisplayBuilderMod(false);
        }

        public void ShowGridVisualization(bool active) {
            _gridVisualization.SetActive(active);
        }

        public void ShowCellIndicator(bool active) {
            _cellIndicator.SetActive(active);
        }

        public void StartPlacementOfObject(int id) {
            _selectedObjectIndex = GameManager.Instance.EntityManager.EntityDatabase[id].GetComponent<Entity>();
            // hud related
            ShowGridVisualization(true);
            ShowCellIndicator(true);
            _playerHud.DisplayBuilderMod(true);
            // ------------------

            _inputBhvr.OnClicked += PlaceObject;
            _inputBhvr.OnExit += StopPlacementOfObject;
        }

        public void PlaceObject() {
            if (!_inputBhvr.IsPointerOverUI()) {
                Vector3 mousePosition = _inputBhvr.GetSelectedMapPosition();
                Vector3Int gridPosition = _floorGrid.WorldToCell(mousePosition);
                GameObject newObject = Instantiate(_selectedObjectIndex.gameObject);

                Entity entity = newObject.GetComponent<Entity>();
                newObject.transform.position = _floorGrid.CellToWorld(gridPosition) + new Vector3(.5f, .5f, .5f);

                entity.DoSpawn();
            }
        }

        public void RegisterNewBuilding() {
            GameBuilding newBuilding = _selectedObjectIndex.gameObject.GetComponent<GameBuilding>();
            GameManager.Instance.BuildingManager.GameBuildingsList.Add(newBuilding);
            GameManager.Instance.GameEconomy.UpdateBuildingList(newBuilding);
        }

        public void StopPlacementOfObject() {
            // hud related
            ShowGridVisualization(false);
            ShowCellIndicator(false);
            _playerHud.DisplayBuilderMod(false);
            // ---------------

            _selectedObjectIndex = null;
            _inputBhvr.OnClicked -= PlaceObject;
            _inputBhvr.OnExit -= StopPlacementOfObject;
        }

        private void FixedUpdate() {
            Vector3 mousePosition = _inputBhvr.GetSelectedMapPosition();
            Vector3Int gridPosition = _floorGrid.WorldToCell(mousePosition);

            _mouseIndicator.transform.position = mousePosition;
            _cellIndicator.transform.position = _floorGrid.CellToWorld(gridPosition) + new Vector3(.5f, .5f, .5f);

#if MS_DEBUGGING_ONLY
            GameManager.Instance.DebuggingTools.UpdateText(gridPosition.x, gridPosition.z);
#endif
        }
    }
}