
using SuperAutoMachines.Core.Machine;
using SuperAutoMachines.Core.Match;

namespace SuperAutoMachines.Gui.Console.Store.Commands
{
    public class BuyCommand : ICommand
    {
        private readonly int indexToBuy;

        public BuyCommand(int indexToBuy)
        {
            this.indexToBuy = indexToBuy;
        }

        public async Task Execute()
        {
            AssignCommand.Machine = GameStore.GetInstance().BuyMachine(indexToBuy);
            await StoreGuiConsole.GetInstance().DrawMachineAssignAndAwait();
        }
    }
}