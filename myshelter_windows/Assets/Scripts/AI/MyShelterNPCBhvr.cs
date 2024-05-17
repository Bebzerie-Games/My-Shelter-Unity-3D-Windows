using UnityEngine;

namespace MyShelterWin64.AI {
    public abstract class MyShelterNPCBhvr : MonoBehaviour {

        public abstract NPC NPCSystem {
            get;
        }

        public abstract AIState CurrentState {
            get;
        }

        public abstract AIStateMachine StateMachine {
            get;
        }

        public void ExecuteStateMachine(NPC npc, IAIState state) {
            state.OnStateEnter(npc);
        }

        private void Update() {
            switch (StateMachine) {
                case AIStateMachine.Idle:
                    NPCSystem.AnimationSystem.SetNoVelocity();
                    return; // do nothing

                case AIStateMachine.Wander:
                case AIStateMachine.AwareOfDanger:
                case AIStateMachine.Attack:


                    // ANIMATION
                    // we're using normalized vector because my ai got suddenly slow when going backward, this is the only fix i know atm

                    NPCSystem.AnimationSystem.PlayAnimation(NPCSystem.Agent.velocity.magnitude);

                    // ---------
                    ExecuteStateMachine(NPCSystem, CurrentState);
                    break;
            }
        }
    }
}