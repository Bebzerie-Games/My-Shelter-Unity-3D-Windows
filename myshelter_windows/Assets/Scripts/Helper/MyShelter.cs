using UnityEngine;
using MyShelterWin64.Game.AI;
using System;
using MyShelterWin64.Game.Building;

namespace MyShelterWin64 {
    /// <summary>
    /// MyShelter helper impl. UnityEngine.Debug additional logging making it more clearer for me
    /// </summary>
    public static class MyShelter {
        public static void MS_Print(this ILogger logger, Type source, string message) {
            Debug.Log($"INFOPRINT [{source.Name}] {message}");    
        }

        public static void MS_PrintWarning(this ILogger logger, Type source, string message) {
            Debug.LogWarning($"WARNPRINT [{source.Name}] {message}");
        }

        public static void MS_PrintError(this ILogger logger, Type source, string message) {
            Debug.LogError($"ERRORPRINT [{source.Name}] {message}");
        }
    }
}