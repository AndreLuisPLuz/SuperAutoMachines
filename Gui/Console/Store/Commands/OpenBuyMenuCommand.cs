
namespace SuperAutoMachines.Gui.Console.Store.Commands
{
    public class OpenBuyMenuCommand : ICommand
    {
        public async Task Execute()
        {
            await StoreGuiConsole.GetInstance().DrawBuyOptionAndAwait();
        }
    }
}