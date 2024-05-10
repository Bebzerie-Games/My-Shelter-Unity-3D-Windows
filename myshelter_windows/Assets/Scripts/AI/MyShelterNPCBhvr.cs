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

        public void ExecuteStateMachine(NPC npc, AIState state) {
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
                    NPCSystem.AnimationSystem.PlayAnimation(isHorizontal: true, NPCSystem.Agent.velocity.z);
                    NPCSystem.AnimationSystem.PlayAnimation(isHorizontal: false, NPCSystem.Agent.velocity.x);

                    ExecuteStateMachine(NPCSystem, CurrentState);
                    break;
            }
        }
    }
}