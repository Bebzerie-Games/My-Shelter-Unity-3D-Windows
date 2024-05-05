using MyShelterWin64.Player;
using UnityEngine;

namespace MyShelterWin64.Game.Manager {
    public class GameManager : MonoBehaviour {
        public static GameManager Instance {
            get; set;
        }

        [Header("Debugging Unit :")]
        [SerializeField] GameObject _debuggingUnitGO;

        // TODO : Faire le système d'habitation par classe des ia
        // TODO : Faire le système d'économie avec XP
        // TODO : Faire le sys. de dialogue entre ia (sys. d'événement aléatoire)
        // TODO : Utiliser un vrai modèle 3d des ia au lieu du placeholder cube

        public string GameVersion {
            get; set;
        }

        [Header("Game Data :")]
        public PlayerCameraBhvr CameraBhvr;

        string GetBuildVersion() => Application.version;
        string GetUnityVersion() => Application.unityVersion;
        string FormatGameVersion() => $"MyShelter v{GetBuildVersion()}\t\t{GetUnityVersion()}";
        
        private void OnEnable() {
            _debuggingUnitGO.SetActive(Debug.isDebugBuild);
        }

        private void Awake() {
            Instance = this;
            DontDestroyOnLoad(Instance);
            GameVersion = FormatGameVersion();

#if UNITY_EDITOR
            Debug.unityLogger.MS_Print(typeof(GameManager), GameVersion);
#endif
        }

#if UNITY_EDITOR
        [ContextMenu("My Shelter/Setup Scene")]
        void SetupScene() {
            if (CameraBhvr == null) {
                Debug.unityLogger.MS_PrintError(typeof(GameManager), $"ref. null CameraBhvr");
            } else
                UnityEditor.EditorGUIUtility.PingObject(CameraBhvr);
        }
#endif
    }
}