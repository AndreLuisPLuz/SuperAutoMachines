using SuperAutoMachines.Core.Battle.Generator;
using SuperAutoMachines.Core.Machine;

namespace SuperAutoMachines.Core.Match
{
    public class Store
    {
        private static Store store;

        public BaseMachine?[] MachinesOnSale { get; set; } = new BaseMachine[3];

        private Store(GeneratorTier tier)
        {
            for (int i = 0; i < 3; i++)
                MachinesOnSale[i] = MachineGenerator.Tier(tier).RandomMachine();
        }

        public BaseMachine BuyMachine(int index)
        {
            var machine = MachinesOnSale[index] ?? throw new NullReferenceException("aaa");

            GameMatch.GetInstance().Coins -= 3;
            MachinesOnSale[index] = null;

            return machine;
        }

        public static Store GetInstance(GeneratorTier tier)
        {
            store = new(tier);
            return store;
        }
    }
}