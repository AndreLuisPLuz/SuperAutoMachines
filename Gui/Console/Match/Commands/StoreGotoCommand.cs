using SuperAutoMachines.Gui.Console.Store;

namespace SuperAutoMachines.Gui.Console.Match.Commands
{
    public class StoreGotoCommand : ICommand
    {
        public async Task Execute()
        {
            await StoreGuiConsole.GetInstance().DrawMenuAndAwait();
        }
    }
}