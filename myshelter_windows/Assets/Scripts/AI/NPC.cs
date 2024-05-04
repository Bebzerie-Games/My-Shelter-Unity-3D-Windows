using UnityEngine;

namespace MyShelterWin64.AI {
    public class NPC : MyShelterNPCBhvr {

        [SerializeField] AIStateMachine _stateMachine = AIStateMachine.Idle;
        [SerializeField] GameObject _aiPannel;
        [SerializeField] AIState[] _states;
        [SerializeField] NPCScriptable _aiProfile;

        public AIState[] AIStates => _states;
        public NPCScriptable AIProfile => _aiProfile;

        public override AIStateMachine StateMachine => _stateMachine;

        public void Evaluate(string argument) {
            if (argument == "DoOpenAIPannel") {
                _aiPannel.SetActive(!_aiPannel.activeSelf);
                return;
            }
            
            if (argument == "DoIdle") {
                SetStateMachine(GetIdleState());
                return;
            }

            if (argument == "DoWander") {
                SetStateMachine(GetWanderState());
                return;
            }
        }

        public AIState GetIdleState() => _states[0];
        public AIState GetWanderState() => _states[1];
        public AIState GetAwareOfDangerState() => _states[2];
        public AIState GetAttackState() => _states[3];

        public void SetNewStateMachine(AIStateMachine state) {
            _stateMachine = state;
            Debug.unityLogger.MS_Print(typeof(NPC), $"{AIProfile.NPCName}     OK {nameof(SetNewStateMachine)} -> AIStateMachine.{nameof(state)}");
        }

        void SetStateMachine(AIState state) {
            OnStateMachine(state, this);
        }
    }
}