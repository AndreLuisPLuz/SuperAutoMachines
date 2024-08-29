using System.Collections;
using SuperAutoMachines.Core.Battle.Generator;
using SuperAutoMachines.Core.Machine;

namespace SuperAutoMachines.Core.Match
{
    public class GameMatch
    {
        private static GameMatch? match;

        public int Coins { get; set; }
        public int Hearts { get; set; }
        public int Trophies { get; set; }
        public int Round { get; private set; }
        public GeneratorTier MaxTier { get; private set; }

        public Machine.Machine?[] PlayerTeam;

        private GameMatch()
        {
            Coins = 10;
            Hearts = 5;
            Trophies = 0;
            Round = 1;

            PlayerTeam = new Machine.Machine[5];
        }

        public static GameMatch GetInstance()
        {
            match ??= new();
            return match;
        }

        public void AddMachine(Machine.Machine machine, int position)
        {
            if (PlayerTeam[position] is not null)
                throw new InvalidOperationException("Spot already occupied!");
            
            PlayerTeam[position] = machine;
        }

        public bool TryRemoveMachine(int position, out Machine.Machine? machine)
        {
            machine = PlayerTeam[position];

            if (machine is not null)
            {
                PlayerTeam[position] = null;
                return true;
            }

            return false;
        }
    }
}