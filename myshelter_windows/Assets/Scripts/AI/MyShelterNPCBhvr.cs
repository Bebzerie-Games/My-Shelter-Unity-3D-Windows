using UnityEngine;

namespace MyShelterWin64.AI {
    public abstract class MyShelterNPCBhvr : MonoBehaviour {

        public abstract AIStateMachine StateMachine {
            get;
        }

        public virtual void OnStateMachine(AIState state, NPC npc) {
            state.OnStateEnter(npc);
        }
    }
}