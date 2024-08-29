using SuperAutoMachines.Core.Battle.Generator;
using SuperAutoMachines.Core.Machine;

namespace SuperAutoMachines.Core.Battle
{
    public class Battle
    {
        private readonly Stack<Fighter> blueTeam = new();
        private readonly Stack<Fighter> redTeam = new();

        public Stack<Fighter> BlueTeam => blueTeam;
        public Stack<Fighter> RedTeam => redTeam;

        public bool HasEnded => BlueTeam.Count >= 0 && RedTeam.Count >= 0;

        public Battle (
                IEnumerable<Machine.Machine> playerTeam,
                GeneratorTier minTier,
                GeneratorTier maxTier)
        {
            foreach (var machine in playerTeam)
            {
                if (machine is not null)
                    blueTeam.Push(new Fighter(machine));
            }
            
            int enemiesQty = Random.Shared.Next(3, 5);
            for (int i = 0; i < enemiesQty; i++)
            {
                var tierToGenerate = (GeneratorTier) Random.Shared.Next((int) minTier, (int) maxTier);
                var RandomMachine = MachineGenerator.Tier(tierToGenerate).RandomMachine();

                redTeam.Push(new Fighter(RandomMachine));
            }
        }

        public BattleResult Solve()
        {
            HandleBattleStart();

            while (!HasEnded)
            {
                HandleFight();
                HandleConsequences();
            }

            if (BlueTeam.Count > 0)
                return BattleResult.WIN;
            
            if (RedTeam.Count > 0)
                return BattleResult.LOSE;

            return BattleResult.DRAW;
        }

        private void HandleBattleStart()
        {
            foreach (var fighter in BlueTeam)
                fighter.BattleStart();
            
            foreach (var fighter in RedTeam)
                fighter.BattleStart();
        }

        private void HandleFight()
        {
            var blueFighter = blueTeam.Peek();
            var redFighter = redTeam.Peek();

            blueFighter.Attack(redFighter);
            redFighter.Attack(blueFighter);
        }

        private void HandleConsequences()
        {
            if (!blueTeam.Peek().IsAlive)
                blueTeam.Pop();
            
            if (!redTeam.Peek().IsAlive)
                redTeam.Pop();
        }
    }

    public enum BattleResult
    {
        WIN, DRAW, LOSE
    }
}