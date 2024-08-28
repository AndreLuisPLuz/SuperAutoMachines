
using SuperAutoMachines.Core.Machine;
using SuperAutoMachines.Core.Match;

namespace SuperAutoMachines.Gui.Console.Store.Commands
{
    public class AssignCommand : ICommand
    {
        private readonly int indexToAssign;
        public static BaseMachine? Machine { get; set; } = null;

        public AssignCommand(int indexToAssign)
        {
            this.indexToAssign = indexToAssign;
        }

        public async Task Execute()
        {
            if (Machine is not null)
                GameMatch.GetInstance().AddMachine(Machine, indexToAssign);
            
            await StoreGuiConsole.GetInstance().DrawMenuAndAwait();
        }
    }
}