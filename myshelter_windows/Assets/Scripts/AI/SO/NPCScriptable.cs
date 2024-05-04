using UnityEngine;

namespace MyShelterWin64.AI {
    [CreateAssetMenu(menuName = "My Shelter/New AI")]
    public class NPCScriptable : ScriptableObject {
        [Header("Profile Data :")]
        [SerializeField] string _npcName;
        [SerializeField] string _npcDescription;
        [SerializeField] NPCClass _npcClass;

        public string NPCName => _npcName;
        public string NPCDescription => _npcDescription;
        public NPCClass NPCClass => _npcClass;
    }
}