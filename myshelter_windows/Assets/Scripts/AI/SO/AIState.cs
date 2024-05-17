using UnityEngine;

namespace MyShelterWin64.AI {
    /// <summary>
    /// States id :
    /// 0 = IDLE
    /// 1 = WANDER
    /// </summary>
    public partial class AIState : ScriptableObject, IAIState {

        public delegate void WhenStateBegin(NPC npc);
        public event WhenStateBegin OnStateBegan;

        public delegate void WhenStateEnd(NPC npc);
        public event WhenStateEnd OnStateEnded;

        bool _hasInvokedStateEnterCallback = false,
            _hasInvokedStateExitCallback = false;

        /// <summary>
        /// first state sequence is enter
        /// </summary>
        /// <param name="npc"></param>
        /// <returns></returns>
        public virtual bool OnStateEnter(NPC npc) {
            if (!_hasInvokedStateEnterCallback) {
                OnStateBegan?.Invoke(npc);
                _hasInvokedStateEnterCallback = true;
            }

            OnStateExecuting(npc);
            return true;
        }

        /// <summary>
        /// second state sequence is executing
        /// </summary>
        /// <param name="npc"></param>
        /// <returns></returns>
        public virtual bool OnStateExecuting(NPC npc) {
            return true;
        }

        /// <summary>
        /// third and final state sequence is exit ... now ending sequence
        /// </summary>
        /// <param name="npc"></param>
        /// <returns></returns>
        public virtual bool OnStateExit(NPC npc) {
            if (!_hasInvokedStateExitCallback) {
                OnStateEnded?.Invoke(npc);
                _hasInvokedStateExitCallback = true;
            }

            return true;
        }
    }
}