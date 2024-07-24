using MyShelterWin64.Game.Manager;
using UnityEngine;

namespace MyShelterWin64.Game.Pooling {
    [CreateAssetMenu(menuName = "My Shelter/New Pool Profile")]
    public class GameEntityPoolSO : ScriptableObject {
        [SerializeField] int _maxEntityDraw = 1024;

#if MS_DEBUGGING_ONLY
        private void OnEnable() {
            GameManager.MS_PRINT(typeof(GameEntityPoolSO), $"{_maxEntityDraw} is the limit of entity on the current game");
        }
#endif
    }
}