namespace SuperAutoMachines.Gui
{
    public interface IBattleGui
    {
        Task DrawBattleStart();
        Task DrawFight();
        Task DrawConsequences();
    }
}