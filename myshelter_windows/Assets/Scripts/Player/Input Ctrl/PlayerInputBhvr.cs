using MyShelterWin64.Game;
using MyShelterWin64.Game.Manager;
using UnityEngine;
using System;
using UnityEngine.EventSystems;
using MyShelterWin64.Game.Building;
using MyShelterWin64.Game.AI;

namespace MyShelterWin64.Game.Player {
    /// <summary>
    /// This script is handling the PlayerCameraBhvr input interaction
    /// </summary>
    public sealed class PlayerInputBhvr : MonoBehaviour {

        [SerializeField] LayerMask _placementLayer;
        [SerializeField] bool _isMouseVisible;

        Vector3 _lastPosition;

        public event Action OnClicked, OnExit;

        private void Start() {
            SetMouse(_isMouseVisible);
        }

        public Vector3 GetSelectedMapPosition() {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = Camera.main.nearClipPlane;
            Ray ray = Camera.main.ScreenPointToRay(mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit, 100, _placementLayer)) {
                _lastPosition = hit.point;
            }

            return _lastPosition;
        }

        public bool IsPointerOverUI() {
            return EventSystem.current.IsPointerOverGameObject();
        }
        
        public void SetMouse(bool visible) {
            Cursor.visible = visible;
        }

        private void FixedUpdate() {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Input.GetMouseButtonDown(0)) {

                OnClicked?.Invoke();

                if (!BuildingPlacementCtrl.IsInBuilderMod) {
                    if (Physics.Raycast(ray, out RaycastHit hit, 100)) {
                        GameObject entityGO = hit.transform.gameObject;

                        switch (hit.transform.tag) {
                            case "Survivor NPC":
                                Entity entity = GameManager.Instance.GamePoolManager.GetPool().SpawnedEntity[entityGO];

                                SetMouse(true);
                                GameHUDCtrl.DoOpenAIPannel(entity);
                                break;

                            case "Infected NPC":
                                break;

                            case "Collectable":
#if MS_DEBUGGING_ONLY
                                GameManager.MS_PRINT(typeof(PlayerInputBhvr), $"clicked\t-> {hit.transform.tag}");
#endif
                                break;
                        }
                    }
                }
            }
            if (Input.GetKeyDown(KeyCode.Escape) || Input.GetMouseButtonDown(1))
                OnExit?.Invoke();
        }
    }
}