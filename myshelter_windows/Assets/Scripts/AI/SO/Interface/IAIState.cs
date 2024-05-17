namespace MyShelterWin64.AI {
    public interface IAIState {
        bool OnStateEnter(NPC npc);
        bool OnStateExecuting(NPC npc);
        bool OnStateExit(NPC npc);
    }
}