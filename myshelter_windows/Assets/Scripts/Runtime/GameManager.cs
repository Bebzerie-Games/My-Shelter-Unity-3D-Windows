using MyShelterWin64.Building;
using MyShelterWin64.Economy;
using MyShelterWin64.Game.Building;
using MyShelterWin64.Player;
using MyShelterWin64.RuntimeDebugging;
using System;
using UnityEngine;

namespace MyShelterWin64.Game.Manager {
    public class GameManager : MonoBehaviour {
        public static GameManager Instance {
            get; set;
        }

        [Header("Debugging Unit :")]
        [SerializeField] GameObject _debuggingUnitGO;
        public MyShelterDebuggingTool DebuggingTools;

        [Header("HUD :")]
        public PlayerHUDCtrl PlayerHUDCtrl;

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

        [Header("Game Data :")]
        public PlayerCameraBhvr CameraBhvr;

        string GetBuildVersion() => Application.version;
        string GetUnityVersion() => Application.unityVersion;
        string FormatGameVersion() => $"MyShelter v{GetBuildVersion()}\t\t{GetUnityVersion()}";

        public readonly static Action<Type, string> MS_PRINT = Debug.unityLogger.MS_Print;
        public readonly static Action<Type, string> MS_PRINT_WRN = Debug.unityLogger.MS_PrintWarning;
        public readonly static Action<Type, string> MS_PRINT_ERR = Debug.unityLogger.MS_PrintError;

        private void OnEnable() {
#if MS_DEBUGGING_ONLY
            _debuggingUnitGO.SetActive(true);
            MS_PRINT(typeof(GameManager), "Debugging is active for this build");
#endif
        }

        private void Awake() {
            Instance = this;
            DontDestroyOnLoad(Instance);
            GameVersion = FormatGameVersion();

#if DEBUG
            MS_PRINT(typeof(GameManager), GameVersion);
#endif
        }
    }
}