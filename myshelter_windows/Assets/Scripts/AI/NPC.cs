using UnityEngine;
using UnityEngine.AI;

namespace MyShelterWin64.AI {
    public class NPC : MyShelterNPCBhvr {

        public NavMeshAgent Agent;
        [Space]
        [SerializeField] AIStateMachine _stateMachine = AIStateMachine.Idle;
        [SerializeField] GameObject _aiPannel;
        [Space]
        [SerializeField] AIState[] _states;
        [SerializeField] AIState _currentState;
        [Space]
        [SerializeField] NPCScriptable _aiProfile;
        [Space]
        public AIAnimationSystem AnimationSystem;

        public AIState[] AIStates => _states;
        public NPCScriptable AIProfile => _aiProfile;

        public override AIStateMachine StateMachine => _stateMachine;

        public override NPC NPCSystem => this;

        public override AIState CurrentState =>_currentState;

        public void AgentSetDestination(Vector3 newPos) {
            Agent.SetDestination(newPos);
        }

        public void Evaluate(string argument) {
            if (argument == "DoOpenAIPannel") {
                _aiPannel.SetActive(!_aiPannel.activeSelf);
                return;
            }
            
            if (argument == "DoIdle") {
                SetNewStateMachine(AIStateMachine.Idle);
            } 
            
            else if (argument == "DoWander") {
                SetNewStateMachine(AIStateMachine.Wander);
            } 
            
            else {
                SetStateMachine(CurrentState);
            }
        }

        public AIState GetIdleState() => _states[0];
        public AIState GetWanderState() => _states[1];
        public AIState GetAwareOfDangerState() => _states[2];
        public AIState GetAttackState() => _states[3];

        public AIState GetAIStateByCurrentStateMachine() {
            Debug.Log((int)_stateMachine);
            return _states[(int)_stateMachine];
        }

        public void SetNewStateMachine(AIStateMachine state) {
            _currentState.OnStateExit(this);

            _stateMachine = state;
            _currentState = GetAIStateByCurrentStateMachine();

            Debug.unityLogger.MS_Print(typeof(NPC), $"{AIProfile.NPCName}     OK {nameof(SetNewStateMachine)} -> AIStateMachine.{nameof(state)}");
        }

        void SetStateMachine(AIState state) {
            ExecuteStateMachine(this, state);
        }
    }
}