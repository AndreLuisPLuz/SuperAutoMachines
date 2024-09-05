using SuperAutoMachines.Core.Match;
using SuperAutoMachines.Gui.Console.Battle;

namespace SuperAutoMachines.Gui.Console.Match.Commands
{
    public class BattleGotoCommand : ICommand
    {
        public async Task Execute()
        {
            GameMatch.GetInstance().DoBattle();
            await BattleGuiConsole.GetInstance().DrawBattleAndAwait();
        }
    }
}