using SuperAutoMachines.Core.Battle.Generator;
using SuperAutoMachines.Core.Machine;
using SuperAutoMachines.Core.Match;
using SuperAutoMachines.Gui;
using SuperAutoMachines.Gui.Factories;

namespace SuperAutoMachines.Core.Battle
{
    public class Battle
    {
        private static Battle battle;

        private Queue<BattleEvent> events = new();
        private readonly Stack<Fighter> blueTeam = new();
        private readonly Stack<Fighter> redTeam = new();
        private int round = 1;

        public BattleEvent CurrentEvent => events.Peek();
        public Stack<Fighter> BlueTeam => blueTeam;
        public Stack<Fighter> RedTeam => redTeam;
        public bool HasEnded => BlueTeam.Count >= 0 && RedTeam.Count >= 0;

        private Battle (
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

        public Battle GetInstance()
        {
            battle ??= new(
                GameMatch.GetInstance().PlayerTeam,
                GeneratorTier.ONE,
                GameMatch.GetInstance().MaxTier);

            return battle;
        }

        public void Reset()
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
            }

            if (BlueTeam.Count > 0){
                GameMatch.GetInstance().Trophies += 1;//
                return BattleResult.WIN;
            }
            
            if (RedTeam.Count > 0)
                return BattleResult.LOSE;

            return BattleResult.DRAW;
        }

        private void HandleBattleStart()
        {
            NewEvent();
            CurrentEvent.RegisterAction("[Battle has started]");

            foreach (var fighter in BlueTeam)
                fighter.BattleStart();
            
            foreach (var fighter in RedTeam)
                fighter.BattleStart();
        }

        private void HandleFight()
        {
            NewEvent();
            CurrentEvent.RegisterAction($"[Round {round} begins]");

            var blueFighter = blueTeam.Peek();
            var redFighter = redTeam.Peek();

            blueFighter.Attack(redFighter);
            redFighter.Attack(blueFighter);
        }

        private void HandleConsequences()
        {
            NewEvent();
            CurrentEvent.RegisterAction($"[Aftermath]");

            var blueFighter = blueTeam.Peek();
            var redFighter = redTeam.Peek();

            if (blueFighter.IsAlive)
            {
                CurrentEvent.RegisterAction($"Blue fighter, {blueFighter.Name}, was defeated.");
                blueTeam.Pop();
            }
            
            if (redFighter.IsAlive)
            {
                CurrentEvent.RegisterAction($"Red fighter, {redFighter.Name}, was defeated.");
                redTeam.Pop();
            }
        }

        private void NewEvent() => events.Enqueue(new BattleEvent());
    }

    public enum BattleResult
    {
        WIN, DRAW, LOSE
    }
}