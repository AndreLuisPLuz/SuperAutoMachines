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

        public Machine.BaseMachine?[] PlayerTeam;

        private GameMatch()
        {
            Coins = 10;
            Hearts = 5;
            Trophies = 0;
            Round = 1;

            PlayerTeam = new Machine.BaseMachine[5];
        }

        public static GameMatch GetInstance()
        {
            match ??= new();
            return match;
        }

        public void AddMachine(Machine.BaseMachine machine, int position)
        {
            if (PlayerTeam[position] is not null)
                throw new InvalidOperationException("Spot already occupied!");
            
            PlayerTeam[position] = machine;
        }

        public bool TryRemoveMachine(int position, out Machine.BaseMachine? machine)
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