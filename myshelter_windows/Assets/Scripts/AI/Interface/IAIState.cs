namespace MyShelterWin64.Game.AI {
    /// <summary>
    /// interface of NPC's state for state machine events
    /// </summary>
    public interface IAIState {
        bool OnStateEnter(NPC npc);
        bool OnStateExecuting(NPC npc);
        bool OnStateExit(NPC npc);
    }
}