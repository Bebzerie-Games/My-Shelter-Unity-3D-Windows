using UnityEngine;

namespace MyShelterWin64 {
    using MyShelterWin64.AI;
    using System;

    /// <summary>
    /// MyShelter helper impl. UnityEngine.Debug additional logging making it more clearer for me
    /// </summary>
    public static class MyShelter {
        public static void MS_Print(this ILogger logger, Type source, string message) {
            Debug.Log($"[{source.Name}] {message}");    
        }

        public static void MS_PrintWarning(this ILogger logger, Type source, string message) {
            Debug.LogWarning($"[{source.Name}] {message}");
        }

        public static void MS_PrintError(this ILogger logger, Type source, string message) {
            Debug.LogError($"[{source.Name}] {message}");
        }
        
        /*
         * TODO : Implementer ceci lorsque le système de dialogue sera commencé
        public static string GetNPCName(this NPCScriptable npcProfile, NPC npc) {
            return npc.AIProfile.NPCName;
        }*/
    }
}