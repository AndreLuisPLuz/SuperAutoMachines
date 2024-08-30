using SuperAutoMachines.Core.Machine;
using SuperAutoMachines.Core.Machine.Generator;
using SuperAutoMachines.Core.Match;

namespace SuperAutoMachines.Core.Battle
{
    public class GameBattle
    {
        private static GameBattle? battle;

        private readonly Stack<Fighter> blueTeam = new();
        private readonly Stack<Fighter> redTeam = new();

        public static int Round { get; private set; }

        public Queue<BattleEvent> Events = new();
        public BattleEvent CurrentEvent => Events.Peek();
        public Stack<Fighter> BlueTeam => blueTeam;
        public Stack<Fighter> RedTeam => redTeam;
        public bool HasEnded => BlueTeam.Count == 0 || RedTeam.Count == 0;

        private GameBattle (
                IEnumerable<BaseMachine?> playerTeam,
                GeneratorTier minTier,
                GeneratorTier maxTier)
        {
            Console.WriteLine(minTier);
            Console.WriteLine(maxTier);

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

            Round = 1;
        }

        public static GameBattle GetInstance()
        {
            battle ??= new(
                GameMatch.GetInstance().PlayerTeam,
                GeneratorTier.ONE,
                GameMatch.GetInstance().MaxTier);
            
            return battle;
        }

        public static void NextRound()
        {
            battle = new(
                GameMatch.GetInstance().PlayerTeam,
                GeneratorTier.ONE,
                GameMatch.GetInstance().MaxTier);
        }

        public BattleResult Solve()
        {
            HandleBattleStart();

            while (!HasEnded)
            {
                HandleFight();
                HandleConsequences();
                Round++;
            }

            if (BlueTeam.Count > 0)
                return BattleResult.WIN;
            
            if (RedTeam.Count > 0)
                return BattleResult.LOSE;

            return BattleResult.DRAW;
        }

        private void HandleBattleStart()
        {
            NewEvent("[Battle has started]");

            foreach (var fighter in BlueTeam)
                fighter.BattleStart();
            
            foreach (var fighter in RedTeam)
                fighter.BattleStart();
        }

        private void HandleFight()
        {
            NewEvent($"[Round {Round} begins]");

            var blueFighter = blueTeam.Peek();
            var redFighter = redTeam.Peek();

            blueFighter.Attack(redFighter);
            redFighter.Attack(blueFighter);
        }

        private void HandleConsequences()
        {
            NewEvent($"[Round {Round} aftermath]");

            var blueFighter = blueTeam.Peek();
            var redFighter = redTeam.Peek();

            if (!blueFighter.IsAlive)
            {
                CurrentEvent.RegisterAction($"Blue fighter, {blueFighter.Name}, was defeated.");
                blueTeam.Pop();
            }
            
            if (!redFighter.IsAlive)
            {
                CurrentEvent.RegisterAction($"Red fighter, {redFighter.Name}, was defeated.");
                redTeam.Pop();
            }
        }

        private void NewEvent(string header) => Events.Enqueue(new BattleEvent(header));
    }

    public enum BattleResult
    {
        WIN, DRAW, LOSE
    }
}