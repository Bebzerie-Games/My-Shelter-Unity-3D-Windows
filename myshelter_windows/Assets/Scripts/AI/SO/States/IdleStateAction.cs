using UnityEngine;

namespace MyShelterWin64.AI {
    [CreateAssetMenu(menuName = "My Shelter/AI States/New Idle State")]
    public class IdleStateAction : AIState {
        public override bool OnStateEnter(NPC npc) {

            base.OnStateEnter(npc);

            Debug.unityLogger.MS_Print(typeof(IdleStateAction), $"{npc.AIProfile.NPCName}     OK {nameof(IdleStateAction)}");
            npc.SetNewStateMachine(AIStateMachine.Idle);
            return true;
        }
    }
}