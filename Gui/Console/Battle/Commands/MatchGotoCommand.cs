
using SuperAutoMachines.Gui.Console.Match;

namespace SuperAutoMachines.Gui.Console.Battle.Commands
{
    public class MatchGotoCommand : ICommand
    {
        public async Task Execute()
        {
            await MatchGuiConsole.GetInstance().DrawMenuAndAwait();
        }
    }
}