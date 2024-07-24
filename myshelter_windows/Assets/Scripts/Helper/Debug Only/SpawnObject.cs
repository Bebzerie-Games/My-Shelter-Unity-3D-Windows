using MyShelterWin64.Game.Manager;
using UnityEngine;

namespace MyShelterWin64.RuntimeDebugging {
    public class SpawnObject : MonoBehaviour {
        [SerializeField] int _entityIdToSpawn;
        [SerializeField] bool _canSpawn;


        private void Start() {
#if MS_DEBUGGING_ONLY
            if (_canSpawn)
                GameManager.Instance.GamePoolManager.GetPool().Spawn(_entityIdToSpawn);
    this.enabled = false;
#endif
        }
    }
}