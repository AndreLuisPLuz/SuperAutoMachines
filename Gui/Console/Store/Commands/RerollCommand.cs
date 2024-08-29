
using SuperAutoMachines.Core.Match;

namespace SuperAutoMachines.Gui.Console.Store.Commands
{
    public class RerollCommand : ICommand
    {
        public async Task Execute()
        {
            GameStore.GetInstance().Reroll();
            await StoreGuiConsole.GetInstance().DrawMenuAndAwait();
        }
    }
}