using MyShelterWin64.Game.Pooling;
using UnityEngine;

namespace MyShelterWin64.Game.Manager {

    public sealed class GameEntityPoolManager : MonoBehaviour {
        [SerializeField] GameEntityPool _entityPool;

        public GameEntityPool GetPool() {
            return _entityPool;
        }
    }
}