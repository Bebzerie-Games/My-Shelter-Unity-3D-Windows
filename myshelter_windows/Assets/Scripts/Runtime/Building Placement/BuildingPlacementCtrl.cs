using MyShelterWin64.Game.Manager;
using MyShelterWin64.Game.Player;
using MyShelterWin64.Game.Pooling;
using UnityEngine;

namespace MyShelterWin64.Game.Building {
    public sealed class BuildingPlacementCtrl : MonoBehaviour {
        [Header("Data :")]
        [SerializeField] GameObject _mouseIndicator;
        [SerializeField] GameObject _cellIndicator;

        [SerializeField] PlayerInputBhvr _inputBhvr;
        [SerializeField] Grid _floorGrid;

        [SerializeField] GameObject _gridVisualization;

        Entity _selectedEntityFromDB = null;

        GridData _placedBuildingsData;

        [SerializeField] Renderer _cellIndicatorColor;

        int _placedBuildingCount = 0;

        public static bool IsInBuilderMod {
            get; set;
        }

        GameHUDCtrl PlayerHUD => GameManager.Instance.GameHUDCtrl;

        private void Start() {
            _placedBuildingsData = new();

            PlayerHUD.DisplayBuilderMod(false);
            ShowGridVisualization(false);
            ShowCellIndicator(false);
        }

        public void ShowGridVisualization(bool active) {
            _gridVisualization.SetActive(active);
        }

        public void ShowCellIndicator(bool active) {
            _cellIndicator.SetActive(active);
        }

        // is linked to button UnityEvent's callback with predefined id atm
        public void StartPlacementOfObject(int id) {
            _selectedEntityFromDB = GameManager.Instance.EntityManager.GetByID(id);
            
            _inputBhvr.OnClicked += PlaceObject;
            _inputBhvr.OnExit += StopPlacementOfObject;

            // hud related
            ShowGridVisualization(true);
            ShowCellIndicator(true);
            PlayerHUD.DisplayBuilderMod(true);
            // ------------------
        }

        // we first take the Entity class from the db and we hook the GameBuilding class from it
        public void PlaceObject() {
            if (!_inputBhvr.IsPointerOverUI()) {
                Vector3 mousePosition = _inputBhvr.GetSelectedMapPosition();
                Vector3Int gridPosition = _floorGrid.WorldToCell(mousePosition);

                bool canBePlaced = CanBePlaced(gridPosition, _selectedEntityFromDB.EntitySO.EntityID);

                if (canBePlaced) {

                    print(GameManager.Instance.GamePoolManager.GetPool().Spawn(_selectedEntityFromDB.EntitySO.EntityID).gameObject.name);
                    
                    GameObject newBuilding = GameManager.Instance.GamePoolManager.GetPool().Spawn(_selectedEntityFromDB.EntitySO.EntityID).gameObject;
                    newBuilding.transform.position = _floorGrid.CellToWorld(gridPosition);

                    _placedBuildingsData.AddObjectAt(gridPosition, GameManager.Instance.EntityManager.GetByID(_selectedEntityFromDB.EntitySO.EntityID).EntitySO.CellsDimension,
                    _selectedEntityFromDB.EntitySO.EntityID, _placedBuildingCount++);

                    RegisterNewBuilding(newBuilding.GetComponent<GameBuilding>());
                }
            }
        }

        public bool CanBePlaced(Vector3Int gridPosition, int selectedEntityID) {
            return _placedBuildingsData.CanPlaceObjectAt(gridPosition, GameManager.Instance.EntityManager.GetByID(selectedEntityID).EntitySO.CellsDimension);
        }

        public void RegisterNewBuilding(GameBuilding building) {
            GameManager.Instance.BuildingManager.GameBuildingsList.Add(building);
            GameManager.Instance.GameEconomy.UpdateBuildingList(building);
        }

        public void StopPlacementOfObject() {
            // hud related
            ShowGridVisualization(false);
            ShowCellIndicator(false);
            PlayerHUD.DisplayBuilderMod(false);
            // ---------------

            _inputBhvr.OnClicked -= PlaceObject;
            _inputBhvr.OnExit -= StopPlacementOfObject;
            _selectedEntityFromDB = null;
        }

        private void Update() {
            if (_selectedEntityFromDB == null)
                return;

            Vector3 mousePosition = _inputBhvr.GetSelectedMapPosition();
            Vector3Int gridPosition = _floorGrid.WorldToCell(mousePosition);

            bool canBePlaced = CanBePlaced(gridPosition, _selectedEntityFromDB.EntitySO.EntityID);
            _cellIndicatorColor.material.color = canBePlaced ? Color.white : Color.red;

            _mouseIndicator.transform.position = mousePosition;
            _cellIndicator.transform.position = _floorGrid.CellToWorld(gridPosition) + new Vector3(.5f, .5f, .5f);

#if MS_DEBUGGING_ONLY
            GameManager.Instance.DebuggingTools.UpdateText(gridPosition.x, gridPosition.z);
#endif
        }
    }
}