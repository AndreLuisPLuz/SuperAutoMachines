using SuperAutoMachines.Core.Machine;

namespace SuperAutoMachines.Core.Battle.Generator
{
    public abstract class Generator
    {
        protected List<Func<BaseMachine>> possibleMachines = new();

        protected abstract void Fill();

        public BaseMachine RandomMachine()
        {
            if (possibleMachines.Count == 0)
                Fill();

            int randomNumber = Random.Shared.Next(0, possibleMachines.Count);
            return possibleMachines[randomNumber]();
        }
    }
}