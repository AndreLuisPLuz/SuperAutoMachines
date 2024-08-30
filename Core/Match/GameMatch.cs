using System.Reflection;
using SuperAutoMachines.Core.Battle;
using SuperAutoMachines.Core.Machine;
using SuperAutoMachines.Core.Machine.Generator;

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

        public void NewRound()
        {
            foreach (var machine in PlayerTeam)
                machine?.OnPrep();

            MaxTier = (GeneratorTier) (Round / 2);
            Round++;
        }

        public void AddMachine(BaseMachine machine, int position)
        {
            var teamMachine = PlayerTeam[position];

            if (teamMachine is not null)
            {
                var storeMachine = machine;

                if (teamMachine.Name != storeMachine.Name)
                    throw new InvalidOperationException("Position already occupied!");
                
                MergeMachines(teamMachine, storeMachine, position);
                return;
            }
            
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

        public void MergeMachines(BaseMachine teamMachine, BaseMachine storeMachine, int position)
        {
            if (teamMachine.Level >= 3 || storeMachine.Level >= 3)
                return;

            int greaterAttack = int.Max(teamMachine.Attack, storeMachine.Attack);
            int greaterHealth = int.Max(teamMachine.Health, storeMachine.Health);

            var type = teamMachine.GetType();
            var constructor = type.GetConstructor(new[] { typeof(bool) }) 
                    ?? throw new NotSupportedException($"BaseMachine constructor for type {type} was not set, and therefore, is not supported.");

            var fusion = (BaseMachine) constructor.Invoke(Array.Empty<object>());

            fusion.Attack = greaterAttack + 1;
            fusion.Health = greaterHealth + 1;
            fusion.RaiseExperienceTo(teamMachine.Experience + storeMachine.Experience);

            PlayerTeam[position] = fusion;
        }

        public void DoBattle()
        {
            GameBattle.NextRound();
            var battleResult = GameBattle.GetInstance().Solve();

            switch (battleResult)
            {
                case BattleResult.WIN:
                    Trophies++;
                    break;
                case BattleResult.LOSE:
                    Hearts--;
                    break;
                default:
                    break;
            }

            NewRound();
        }
    }
}