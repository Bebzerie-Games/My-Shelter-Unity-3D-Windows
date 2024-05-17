using UnityEngine;

namespace MyShelterWin64.AI {
    [CreateAssetMenu(menuName = "My Shelter/AI States/New Idle State")]
    public class IdleStateAction : AIState {
        public override bool OnStateEnter(NPC npc) {
            return base.OnStateEnter(npc);
        }
    }
}