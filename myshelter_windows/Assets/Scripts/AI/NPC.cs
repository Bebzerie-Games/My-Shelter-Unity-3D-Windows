using MyShelterWin64.Game.Manager;
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

        public bool AgentSetDestination(Vector3 newPos) {
            return Agent.SetDestination(newPos);
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

        public IAIState GetIdleState() => _states[0];
        public IAIState GetWanderState() => _states[1];
        public IAIState GetAwareOfDangerState() => _states[2];
        public IAIState GetAttackState() => _states[3];

        public AIState GetAIStateByCurrentStateMachine() {
            Debug.Log((int)_stateMachine);
            return _states[(int)_stateMachine];
        }

        public void SetNewStateMachine(AIStateMachine state) {
            _currentState.OnStateExit(this);

            _stateMachine = state;
            _currentState = GetAIStateByCurrentStateMachine();

#if DEBUG
            GameManager.MS_PRINT(typeof(NPC), $"{AIProfile.NPCName}     OK {nameof(SetNewStateMachine)} -> AIStateMachine.{nameof(state)}");
#endif
        }

        void SetStateMachine(IAIState state) {
            ExecuteStateMachine(this, state);
        }
    }
}