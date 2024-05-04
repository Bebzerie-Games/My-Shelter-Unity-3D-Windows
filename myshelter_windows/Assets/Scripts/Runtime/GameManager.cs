using MyShelterWin64.Player;
using UnityEngine;

namespace MyShelterWin64.Game.Manager {
    public class GameManager : MonoBehaviour {
        public static GameManager Instance {
            get; set;
        }

        public readonly string GameVersion = Application.version;
        public readonly string IsGameDebug = Debug.isDebugBuild ? "not production ready" : "production ready";

        [Header("Game Data :")]
        public PlayerCameraBhvr CameraBhvr;

        private void Awake() {
            Instance = this;
            DontDestroyOnLoad(Instance);
#if UNITY_EDITOR
            Debug.unityLogger.MS_Print(typeof(GameManager), $"MyShelter v{GameVersion} {IsGameDebug}");
#endif
        }

        [ContextMenu("My Shelter/Setup Scene")]
        void SetupScene() {
            if (CameraBhvr == null) {
                Debug.unityLogger.MS_PrintError(typeof(GameManager), $"ref. null CameraBhvr");
            } else
                UnityEditor.EditorGUIUtility.PingObject(CameraBhvr);
        }
    }
}