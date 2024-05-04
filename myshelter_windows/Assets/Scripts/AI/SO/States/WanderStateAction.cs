using UnityEngine;

namespace MyShelterWin64.AI {
    [CreateAssetMenu(menuName = "My Shelter/AI States/New Wander State")]
    public class WanderStateAction : AIState {
        public override bool OnStateEnter(NPC npc) {
            Debug.unityLogger.MS_Print(typeof(WanderStateAction), $"{npc.AIProfile.NPCName}     OK {nameof(WanderStateAction)}");
            npc.SetNewStateMachine(AIStateMachine.Wander);
            return true;
        }

        public override bool OnStateExit(NPC npc) {
            return true;
        }
    }
}