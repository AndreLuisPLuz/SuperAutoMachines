using SuperAutoMachines.Core.Machine;
using SuperAutoMachines.Core.Machine.Types;

namespace SuperAutoMachines.Core.Battle.Generator
{
    public class TierOneGenerator : Generator
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