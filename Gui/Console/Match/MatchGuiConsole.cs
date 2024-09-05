
using SuperAutoMachines.Core.Match;
using SuperAutoMachines.Gui.Console.Match.Commands;

namespace SuperAutoMachines.Gui.Console.Match
{
    public class MatchGuiConsole : IMatchGui
    {
        private static MatchGuiConsole? console;

        private readonly Dictionary<int, ICommand?> commandMap = new();
        private readonly ConsoleButton battleButton;
        private readonly ConsoleButton storeButton;

        private MatchGuiConsole()
        {
            battleButton = new ConsoleButton(1, "Go to battle", new BattleGotoCommand());
            storeButton = new ConsoleButton(2, "Go to store", new StoreGotoCommand());

            commandMap.Add(battleButton.Option, battleButton.Command);
            commandMap.Add(storeButton.Option, storeButton.Command);
        }

        public static MatchGuiConsole GetInstance()
        {
            console ??= new();
            return console;
        }

        public async Task DrawMenuAndAwait()
        {
            System.Console.Clear();

            int hearts = GameMatch.GetInstance().Hearts;
            int trophies = GameMatch.GetInstance().Trophies;
            int coins = GameMatch.GetInstance().Coins;
            int round = GameMatch.GetInstance().Round;

            System.Console.WriteLine($"=================================== MATCH ===================================");
            System.Console.WriteLine($"{hearts} Hearts\t{trophies} Trophies\t{coins} Coins");
            System.Console.WriteLine($"Round: {round}");

            var team = GameMatch.GetInstance().PlayerTeam;
            System.Console.WriteLine("\n");

            foreach (var machine in team)
            {
                string representation = machine?.Name ?? "[empty]";
                System.Console.Write($"{representation}\t");
            }

            System.Console.WriteLine($"\n\n================================== OPTIONS ===================================");
            battleButton.Draw();
            storeButton.Draw();

            int option = Int32.Parse(System.Console.ReadLine());
            commandMap.TryGetValue(option, out var command);

            if (command is not null)
                await command.Execute();
        }
    }
}