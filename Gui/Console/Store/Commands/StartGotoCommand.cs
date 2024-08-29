
namespace SuperAutoMachines.Gui.Console.Store.Commands
{
    public class StartGotoCommand : ICommand
    {
        public async Task Execute()
        {
            await StoreGuiConsole.GetInstance().DrawMenuAndAwait();
        }
    }
}