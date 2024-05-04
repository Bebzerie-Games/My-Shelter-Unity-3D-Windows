using MyShelterWin64.Game;
using UnityEngine;

namespace MyShelterWin64.Player {
    /// <summary>
    /// This script is handling the PlayerCameraBhvr input interaction
    /// </summary>
    public class PlayerInputBhvr : MonoBehaviour {
        private void FixedUpdate() {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Input.GetMouseButtonDown(0) && Physics.Raycast(ray, out hit, 100)) {
                hit.transform.GetComponent<Entity>().OnInteractionEnter.Invoke("DoOpenAIPannel");
            }
        }
    }
}