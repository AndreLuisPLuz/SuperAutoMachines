using SuperAutoMachines.Core.Machine;
using SuperAutoMachines.Core.Machine.Types;

namespace SuperAutoMachines.Core.Battle.Generator
{
    public class TierOneGenerator : Generator
    {
        protected override void Fill()
        {
            possibleMachines.Add(new Belt());
            possibleMachines.Add(new Hammer());
            possibleMachines.Add(new Screwdriver());
        }
    }
}