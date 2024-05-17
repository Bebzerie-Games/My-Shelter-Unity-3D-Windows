#define MS_DEBUGGING_ONLY

using TMPro;
using UnityEngine;

#if MS_DEBUGGING_ONLY
namespace MyShelterWin64.RuntimeDebugging {
    public class MyShelterDebuggingTool : MonoBehaviour {
        [Header("Debugging TMP :")]
        [SerializeField] TextMeshProUGUI _gridWorldSpaceCoord;

        public void UpdateText(int xCoord, int yCoord) {
            _gridWorldSpaceCoord.text = $"x:{xCoord} y:{yCoord}";
        }
    }
}
#endif