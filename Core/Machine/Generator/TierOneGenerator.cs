using SuperAutoMachines.Core.Battle.Generator;
using SuperAutoMachines.Core.Machine.Types.TierOne;

namespace SuperAutoMachines.Core.Machine.Generator
{
    public class TierOneGenerator : BaseGenerator
    {
        protected override void Fill()
        {
            possibleMachines.Clear();
            possibleMachines.Add(() => new Belt(true));
            possibleMachines.Add(() => new Hammer(true));
            possibleMachines.Add(() => new Screwdriver(true));
            possibleMachines.Add(() => new Drill(true));
        }
    }
}