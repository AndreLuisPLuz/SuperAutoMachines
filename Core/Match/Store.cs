using SuperAutoMachines.Core.Battle.Generator;
using SuperAutoMachines.Core.Machine;

namespace SuperAutoMachines.Core.Match
{
    public class Store
    {
        private static Store store;

        public GeneratorTier MaxTier { get; set; }
        public int MachinesCount { get; set; }
        public BaseMachine?[] MachinesOnSale { get; set; }

        private Store()
        {
            MaxTier = GeneratorTier.ONE;
            MachinesCount = 3;

            GenerateMachinesOnSale();
        }

        public static Store GetInstance()
        {
            store ??= new();
            return store;
        }

        public BaseMachine BuyMachine(int index)
        {
            var machine = MachinesOnSale[index] ?? throw new NullReferenceException("No machine on this position.");

            MachinesOnSale[index] = null;
            MachinesCount -= 1;

            GameMatch.GetInstance().Coins -= 3;

            return machine;
        }

        public void Reroll()
        {
            GameMatch.GetInstance().Coins -= 1;
            GenerateMachinesOnSale();
        }

        private void GenerateMachinesOnSale()
        {
            MachinesOnSale = new BaseMachine?[MachinesCount];
            
            for (int i = 0; i < MachinesCount; i++)
            {
                var tierToGenerate = (GeneratorTier) Random.Shared.Next(1, (int) MaxTier);
                MachinesOnSale[i] = MachineGenerator.Tier(tierToGenerate).RandomMachine();
            }
        }
    }
}