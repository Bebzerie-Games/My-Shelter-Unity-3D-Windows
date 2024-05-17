using MyShelterWin64.Game;
using MyShelterWin64.Game.Manager;
using UnityEngine;
using System;
using UnityEngine.EventSystems;
using MyShelterWin64.Game.Building;

namespace MyShelterWin64.Player {
    /// <summary>
    /// This script is handling the PlayerCameraBhvr input interaction
    /// </summary>
    public class PlayerInputBhvr : MonoBehaviour {

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

                if (!BuildingPlacementCtrl.IsInBuilderMod && Physics.Raycast(ray, out RaycastHit hit, 100)) {
                    switch (hit.transform.tag) {
                        case "Survivor NPC":
                            SetMouse(true);
                            PlayerHUDCtrl.DoOpenAIPannel(hit.transform.GetComponent<Entity>());
                            break;

                        case "Infected NPC":
                            break;

                        case "Building":
                            SetMouse(true);
#if DEBUG
                            GameManager.MS_PRINT(typeof(PlayerInputBhvr), $"clicked\t-> {hit.transform.tag}");
                            hit.transform.GetComponent<Entity>().DoInteractionEnter();
#endif
                            break;

                        case "Collectable":
#if DEBUG
                            GameManager.MS_PRINT(typeof(PlayerInputBhvr), $"clicked\t-> {hit.transform.tag}");
#endif
                            break;
                    }
                }
            }
            if (Input.GetKeyDown(KeyCode.Escape) || Input.GetMouseButtonDown(1))
                OnExit?.Invoke();
        }
    }
}