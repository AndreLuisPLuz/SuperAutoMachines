using System.Collections;
using SuperAutoMachines.Core.Machine;

namespace SuperAutoMachines.Core.Match
{
    public class GameMatch
    {
        private static GameMatch? match;

        public int Coins { get; set; }
        public int Hearts { get; set; }
        public int Trophies { get; set; }
        public int Round { get; set; }

        public BaseMachine?[] PlayerTeam;

        private GameMatch()
        {
            Coins = 10;
            Hearts = 5;
            Trophies = 0;
            Round = 1;

            PlayerTeam = new BaseMachine[5];
        }

        public static GameMatch GetInstance()
        {
            match ??= new();
            return match;
        }

        public void AddMachine(BaseMachine machine, int position)
        {
            if (PlayerTeam[position] is not null)
                throw new InvalidOperationException("Spot already occupied!");
            
            PlayerTeam[position] = machine;
        }

        public bool TryRemoveMachine(int position, out BaseMachine? machine)
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