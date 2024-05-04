using System;
using UnityEngine;

namespace MyShelterWin64.AI {
    /// <summary>
    /// States id :
    /// 0 = IDLE
    /// 1 = WANDER
    /// </summary>
    public partial class AIState : ScriptableObject {

        public delegate void WhenStateBegin(NPC npc);
        public event WhenStateBegin OnStateBegan;

        public delegate void WhenStateEnd(NPC npc);
        public event WhenStateEnd OnStateEnded;

        public virtual bool OnStateEnter(NPC npc) {
            OnStateBegan?.Invoke(npc);
            return true;
        }
        public virtual bool OnStateExit(NPC npc) {
            OnStateEnded?.Invoke(npc);
            return true;
        }
    }
}