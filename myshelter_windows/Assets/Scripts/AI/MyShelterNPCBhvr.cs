namespace MyShelterWin64.Game.AI {
    /// <summary>
    /// NPC's state machine where the state are involved
    /// </summary>
    public abstract class MyShelterNPCBhvr : Entity {

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

        private void OnEnable() {
            OnInteractionEnter += () => {
                GetNPCCallbacks().SetActive(!GetNPCCallbacks().activeSelf);
            };

            OnEntitySpawn += () => {
                NPCSystem.Evaluate(CurrentState.name);
            };
        }

        private void Update() {
            switch (StateMachine) {
                case AIStateMachine.Idle:
                    NPCSystem.AnimationSystem.SetNoVelocity();
                    return; // do nothing

                case AIStateMachine.Wander:
                case AIStateMachine.AwareOfDanger:
                case AIStateMachine.Attack:
                    NPCSystem.AnimationSystem.PlayAnimation(NPCSystem.Agent.velocity.magnitude);

                    ExecuteStateMachine(NPCSystem, CurrentState);
                    break;
            }
        }
    }
}