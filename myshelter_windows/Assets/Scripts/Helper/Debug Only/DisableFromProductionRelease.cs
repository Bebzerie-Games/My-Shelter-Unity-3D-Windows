using UnityEngine;

namespace MyShelterWin64.RuntimeDebugging {
    public sealed class DisableFromProductionRelease : MonoBehaviour {
#if !MS_DEBUGGING_ONLY
    private void Start() {
        gameObject.SetActive(false);
    }
#endif
    }
}