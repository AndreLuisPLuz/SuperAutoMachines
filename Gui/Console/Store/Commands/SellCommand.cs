
using SuperAutoMachines.Core.Match;

namespace SuperAutoMachines.Gui.Console.Store.Commands
{
    public class SellCommand : ICommand
    {
        private readonly int indexToSell;

        public SellCommand(int indexToSell)
        {
            this.indexToSell = indexToSell;
        }

        public async Task Execute()
        {
            GameStore.SellMachine(indexToSell);
            await StoreGuiConsole.GetInstance().DrawMenuAndAwait();
        }
    }
}