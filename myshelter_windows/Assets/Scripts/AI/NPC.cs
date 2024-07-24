using MyShelterWin64.Game.Manager;
using System;
using UnityEngine;
using UnityEngine.AI;

namespace MyShelterWin64.Game.AI {
    /// <summary>
    /// This is the main NPC component
    /// </summary>
    public sealed class NPC : MyShelterNPCBhvr {

        public NavMeshAgent Agent;
        [Space]
        [SerializeField] AIStateMachine _stateMachine = AIStateMachine.Idle;
        [Space]
        [SerializeField] AIState _currentState;
        [Space]
        [SerializeField] NPCSO _aiProfile;
        [Space]
        public AIAnimationSystem AnimationSystem;

        public override event Action OnInteractionEnter;
        public override event Action OnInteractionExit;
        public override event Action OnEntitySpawn;

        public AIState[] AIStates => _aiProfile.NPCStates;
        public NPCSO AIProfile => _aiProfile;

        public override AIStateMachine StateMachine => _stateMachine;

        public override NPC NPCSystem => this;

        public override AIState CurrentState =>_currentState;

        public bool AgentSetDestination(Vector3 newPos) {
            return Agent.SetDestination(newPos);
        }

        // only executed when called, it does not run in loop
        public void Evaluate(string argument) {
            switch (argument) {
                case "DoOpenAIPannel":
                    GetNPCCallbacks().SetActive(!GetNPCCallbacks().activeSelf);
                    return;

                case "DoIdle":
                    SetNewState(AIStateMachine.Idle);
                    break;

                case "DoWander":
                    SetNewState(AIStateMachine.Wander);
                    break;

                default:
                    break;
            }
        }

        public IAIState GetIdleState() => AIStates[0];
        public IAIState GetWanderState() => AIStates[1];
        public IAIState GetAwareOfDangerState() => AIStates[2];
        public IAIState GetAttackState() => AIStates[3];

        /// <summary>
        /// working with enums, each enum will declare which AIState to invoke
        /// </summary>
        /// <param name="state">the state to invoke</param>
        public void SetNewState(AIStateMachine state) {
            _currentState.OnStateExit(this);

            _stateMachine = state;
            _currentState = AIStates[(int)state];

#if MS_DEBUGGING_ONLY
            GameManager.MS_PRINT(typeof(NPC), $"{EntitySO.EntityName}     OK {nameof(SetNewState)} -> AIStateMachine.{nameof(state)}");
#endif
        }

        public override void OnSpawn() {
            OnEntitySpawn.Invoke();
        }

        public override void DoInteractionEnter() {
            OnInteractionEnter.Invoke();
        }

        public override void DoInteractionExit() {
            OnInteractionExit.Invoke();
        }
    }
}