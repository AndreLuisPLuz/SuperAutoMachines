using SuperAutoMachines.Core.Battle.Generator;
using SuperAutoMachines.Core.Machine.Types.TierTwo;

namespace SuperAutoMachines.Core.Machine.Generator
{
    public class TierTwoGenerator : BaseGenerator
    {
        protected override void Fill()
        {
            possibleMachines.Clear();
            possibleMachines.Add(() => new ColumnDrill(true));
            possibleMachines.Add(() => new GasOven(true));
            possibleMachines.Add(() => new FlatGrinder(true));
        }
    }
}