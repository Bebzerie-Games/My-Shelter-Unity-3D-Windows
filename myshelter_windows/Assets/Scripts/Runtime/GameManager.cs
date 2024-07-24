using MyShelterWin64.Game.Economy;
using MyShelterWin64.Game.Building;
using MyShelterWin64.Game.Player;
using MyShelterWin64.RuntimeDebugging;
using System;
using UnityEngine;

namespace MyShelterWin64.Game.Manager {
    public sealed class GameManager : MonoBehaviour {
        public static GameManager Instance {
            get {
                if (_instance == null) {
                    _instance = FindObjectOfType<GameManager>();
                }

                return _instance;
            }
        }
        static GameManager _instance; // derived from FindObjectOfType (tips from ytb InfaillibleCode)

        [Header("Debugging Unit :")]
        [SerializeField] GameObject _debuggingUnitGO;
        public MyShelterDebuggingTool DebuggingTools;

        [Header("Game Pooling :")]
        public GameEntityPoolManager GamePoolManager;

        [Header("HUD :")]
        public GameHUDCtrl GameHUDCtrl;

        [Header("Economy :")]
        public GameEconomyBhvr GameEconomy;

        [Header("Building :")]
        public BuildingPlacementCtrl BuildingPlacement;
        public GameBuildingManager BuildingManager;

        [Header("Entity :")]
        public GameEntityManager EntityManager;

        // TODO : Faire le système de construction de maison avec pooling
        // TODO : Faire le système d'économie avec XP
        // TODO : Faire le système d'habitation par classe des ia
        // TODO : Faire le sys. de dialogue entre ia (sys. d'événement aléatoire)

        public string GameVersion {
            get; set;
        }

        string GetBuildVersion() => Application.version;
        string GetUnityVersion() => Application.unityVersion;
        string FormatGameVersion() => $"MyShelter v{GetBuildVersion()}\t\t{GetUnityVersion()}";

        public readonly static Action<Type, string> MS_PRINT = Debug.unityLogger.MS_Print;
        public readonly static Action<Type, string> MS_PRINT_WRN = Debug.unityLogger.MS_PrintWarning;
        public readonly static Action<Type, string> MS_PRINT_ERR = Debug.unityLogger.MS_PrintError;

        private void OnEnable() {
#if MS_DEBUGGING_ONLY
            _debuggingUnitGO.SetActive(true);
            MS_PRINT(typeof(GameManager), $"Debugging : {_debuggingUnitGO.gameObject.activeSelf}");
            MS_PRINT(typeof(GameManager), $"Pooling : {GamePoolManager.gameObject.activeSelf}");
#endif
        }

        private void Awake() {
            // preventing of having other instance of GameManager fucking up the system
            if (_instance != null)
                Destroy(this);

            DontDestroyOnLoad(this);
            GameVersion = FormatGameVersion();

#if MS_DEBUGGING_ONLY
            MS_PRINT(typeof(GameManager), GameVersion);
#endif
        }
    }
}