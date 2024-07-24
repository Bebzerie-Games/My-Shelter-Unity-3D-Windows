using UnityEngine;

namespace MyShelterWin64.Game.Player {
    /// <summary>
    /// MyShelter's player camera behaviour (movement, zoom, handling click callback receiver, ...)
    /// </summary>
    public sealed class PlayerCameraBhvr : MonoBehaviour {
        readonly float _moveSpeed = 30f;
        readonly float _rotateSpeed = 90f;
        readonly int _edgeScrollSide = 20;

        float _fov = 0, _velocity = 0;

        private void Update() {
            // MOVEMENT
            Vector3 moveDir = transform.forward * Input.GetAxis("Vertical") + transform.right *
                Input.GetAxis("Horizontal");

            transform.position += _moveSpeed * Time.deltaTime * moveDir;

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

            transform.eulerAngles += new Vector3(0, rotateDir * _rotateSpeed * Time.deltaTime, 0);
            // -----------------------------
            // CAMERA ZOOM
            float scroll = Input.GetAxis("Mouse ScrollWheel");

            _fov -= scroll * 2;
            _fov = Mathf.Clamp(_fov, 10, 15);
            Camera.main.orthographicSize = Mathf.SmoothDamp(Camera.main.orthographicSize, _fov, ref _velocity, .25f);
        }
    }
}