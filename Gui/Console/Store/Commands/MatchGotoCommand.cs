using SuperAutoMachines.Gui.Console.Match;

namespace SuperAutoMachines.Gui.Console.Store.Commands
{
    public class MatchGotoCommand : ICommand
    {
        public async Task Execute()
        {
            await MatchGuiConsole.GetInstance().DrawMenuAndAwait();
        }
    }
}