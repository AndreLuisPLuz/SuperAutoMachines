namespace SuperAutoMachines.Gui.Console.Store.Commands
{
    public class OpenSellMenuCommand : ICommand
    {
        public async Task Execute()
        {
            await StoreGuiConsole.GetInstance().DrawSellOptionAndAwait();
        }
    }
}