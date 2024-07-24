using UnityEngine;

namespace MyShelterWin64.Game.AI {
    /// <summary>
    /// NPC profile data that are linked to him
    /// </summary>
    [CreateAssetMenu(menuName = "My Shelter/New AI")]
    public class NPCSO : ScriptableObject {
        [Header("Profile Data :")]

        [SerializeField] NPCClass _npcClass;
        [SerializeField] EntitySO _npcEntity;
        [SerializeField] AIState[] _npcStates;

        public NPCClass NPCClass => _npcClass;
        public EntitySO NPCEntity => _npcEntity;
        public AIState[] NPCStates => _npcStates;
    }
}