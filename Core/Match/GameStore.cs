using SuperAutoMachines.Core.Battle.Generator;
using SuperAutoMachines.Core.Machine;

namespace SuperAutoMachines.Core.Match
{
    public class GameStore
    {
        private static GameStore? store;

        public GeneratorTier MaxTier { get; set; }
        public int MachinesCount { get; set; }
        public BaseMachine?[] MachinesOnSale { get; set; }

        private GameStore()
        {
            MaxTier = GeneratorTier.ONE;
            MachinesCount = 3;

            MachinesOnSale = new BaseMachine?[MachinesCount];
            GenerateMachinesOnSale();
        }

        public static GameStore GetInstance()
        {
            store ??= new();
            return store;
        }

        public BaseMachine BuyMachine(int index)
        {
            var machine = MachinesOnSale[index] ?? throw new NullReferenceException("No machine on this position.");

            if (GameMatch.GetInstance().Coins < 3)
                throw new InvalidOperationException("Insufficient coins!");

            MachinesOnSale[index] = null;
            MachinesCount -= 1;

            GameMatch.GetInstance().Coins -= 3;

            return machine;
        }

        public void SellMachine(int index)
        {
            bool sucess = GameMatch.GetInstance().TryRemoveMachine(index, out var machine);
        }

        public void Reroll()
        {
            if (GameMatch.GetInstance().Coins < 1)
                throw new InvalidOperationException("Insufficient coins!");

            GameMatch.GetInstance().Coins -= 1;

            MachinesOnSale = new BaseMachine?[MachinesCount];
            GenerateMachinesOnSale();
        }

        private void GenerateMachinesOnSale()
        {
            for (int i = 0; i < MachinesCount; i++)
            {
                var tierToGenerate = (GeneratorTier) Random.Shared.Next(1, (int) MaxTier);
                MachinesOnSale[i] = MachineGenerator.Tier(tierToGenerate).RandomMachine();
            }
        }
    }
}