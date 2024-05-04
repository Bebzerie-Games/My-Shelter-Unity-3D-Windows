using UnityEngine;
using UnityEngine.Rendering;

namespace MyShelterWin64.Player {
    /// <summary>
    /// MyShelter's player camera behaviour (movement, zoom, handling click callback receiver, ...)
    /// </summary>
    public class PlayerCameraBhvr : MonoBehaviour {
        [Header("Camera Data :")]
        [SerializeField] Camera _gameCamera;

        // click to drag feature
        Vector2 _lastMousePosition;
        bool _dragPanMoveActive = false;
        // ---------------------

        readonly float _moveSpeed = 30f;
        readonly float _rotateSpeed = 90f;
        readonly int _edgeScrollSide = 20;

        float _fov = 0, _velocity = 0;

        private void Update() {

            bool useAccelerator = Input.GetKeyDown(KeyCode.LeftShift);

            // MOVEMENT
            Vector3 moveDir = transform.forward * Input.GetAxis("Vertical") + transform.right *
                Input.GetAxis("Horizontal");

            if (useAccelerator)
                transform.position += moveDir * Mathf.Lerp(_moveSpeed, _moveSpeed + 4, .25f) * Time.deltaTime;
            else {
                transform.position += moveDir * _moveSpeed * Time.deltaTime;
            }

            // --------------------

            // EDGE SCROLL SIDE
            if (Input.mousePosition.x < _edgeScrollSide)
                moveDir.x = -1;
            if (Input.mousePosition.y < _edgeScrollSide)
                moveDir.z = -1;

            else {
                if (Input.mousePosition.x > Screen.width - _edgeScrollSide)
                    moveDir.x = 1;

                if (Input.mousePosition.y > Screen.width - _edgeScrollSide)
                    moveDir.z = 1;
            }
            // --------------------

            // ROTATION (Both key input and mouse right click)
            float rotateDir = 0f;

            if (Input.GetKey(KeyCode.Q)) rotateDir = +1;
            if (Input.GetKey(KeyCode.E)) rotateDir = -1;

            if (Input.GetMouseButton(1)) {
                _dragPanMoveActive = true;
                _lastMousePosition = Input.mousePosition;
            }

            if (Input.GetMouseButtonUp(1))
                _dragPanMoveActive = false;

            if (_dragPanMoveActive) {
                Vector2 mouseMovementDelta = (Vector2)Input.mousePosition - _lastMousePosition;

                moveDir.x = mouseMovementDelta.x * 20f;
                moveDir.z = mouseMovementDelta.y * 20f;

                _lastMousePosition = Input.mousePosition;
            }

            transform.eulerAngles += new Vector3(0, rotateDir * _rotateSpeed * Time.deltaTime, 0);
            // -----------------------------
            // CAMERA ZOOM
            float scroll = Input.GetAxis("Mouse ScrollWheel");

            _fov -= scroll * 2;
            _fov = Mathf.Clamp(_fov, 2, 8);
            _gameCamera.orthographicSize = Mathf.SmoothDamp(_gameCamera.orthographicSize, _fov, ref _velocity, .25f);
        }
    }
}