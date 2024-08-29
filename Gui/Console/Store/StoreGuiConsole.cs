
using System.Reflection.PortableExecutable;
using SuperAutoMachines.Core.Match;
using SuperAutoMachines.Gui.Console.Store.Commands;

namespace SuperAutoMachines.Gui.Console.Store
{
    public class StoreGuiConsole : IStoreGui
    {
        private static StoreGuiConsole? console;

        private readonly Dictionary<int, ConsoleButton> menuButtonMap = new();
        private readonly Dictionary<int, ConsoleButton> buyButtonMap = new();
        private readonly Dictionary<int, ConsoleButton> sellButtonMap = new();

        private readonly ConsoleButton buyMenuButton;
        private readonly ConsoleButton sellMenuButton;
        private readonly ConsoleButton rerollButton;
        private readonly ConsoleButton gobackButton;

        private readonly ConsoleButton cancelBuyButton;

        private readonly ConsoleButton cancelSellButton;

        private StoreGuiConsole()
        {
            buyMenuButton = new ConsoleButton(1, "Buy new machine.", new OpenBuyMenuCommand());
            sellMenuButton = new ConsoleButton(2, "Sell a machine.", new OpenSellMenuCommand());
            rerollButton = new ConsoleButton(3, "Reroll machines on sale.", new RerollCommand());
            gobackButton = new ConsoleButton(9, "Go back.", new MatchGotoCommand());

            menuButtonMap.Add(buyMenuButton.Option, buyMenuButton);
            menuButtonMap.Add(sellMenuButton.Option, sellMenuButton);
            menuButtonMap.Add(rerollButton.Option, rerollButton);
            menuButtonMap.Add(gobackButton.Option, gobackButton);

            cancelBuyButton = new ConsoleButton(9, "Go back.", new StartGotoCommand());
            buyButtonMap.Add(cancelBuyButton.Option, cancelBuyButton);

            cancelSellButton = new ConsoleButton(9, "Go back.", new StartGotoCommand());
            sellButtonMap.Add(cancelSellButton.Option, cancelSellButton);
        }

        public static StoreGuiConsole GetInstance()
        {
            console ??= new();
            return console;
        }

        public async Task DrawMenuAndAwait()
        {
            System.Console.Clear();
            System.Console.WriteLine($"=================================== STORE ===================================");

            var coins = GameMatch.GetInstance().Coins;
            System.Console.WriteLine($"{coins} Coins");

            System.Console.WriteLine("\nYour team:");

            var team = GameMatch.GetInstance().PlayerTeam;
            foreach (var machine in team)
            {
                string representation = machine?.Name ?? "[empty]";
                System.Console.Write($"{representation}\t");
            }

            System.Console.WriteLine("\n\nMachines on sale:");

            var store = GameStore.GetInstance().MachinesOnSale;
            foreach (var machine in store)
            {
                string representation = machine?.Name ?? "[empty]";
                System.Console.Write($"{representation}\t");
            }

            System.Console.WriteLine("\n\n=================================== OPTIONS ===================================");
            buyMenuButton.Draw();
            sellMenuButton.Draw();
            rerollButton.Draw();
            gobackButton.Draw();

            int option = Int32.Parse(System.Console.ReadLine());
            menuButtonMap.TryGetValue(option, out var button);

            if (button is not null)
                await button.Execute();
        }

        public async Task DrawBuyOptionAndAwait()
        {
            System.Console.Clear();
            System.Console.WriteLine($"=================================== STORE ===================================");

            var coins = GameMatch.GetInstance().Coins;
            System.Console.WriteLine($"{coins} Coins");

            System.Console.WriteLine("\nMachines on sale:");

            var store = GameStore.GetInstance().MachinesOnSale;
            for (int i = 0; i < store.Length; i++)
            {
                var machine = store[i];

                string representation = machine?.Name ?? "empty";
                string description = machine?.Description ?? "no special ability";
                int attack = machine?.Attack ?? 0;
                int health = machine?.Health ?? 0;

                if (machine is not null)
                {
                    var machineButton = new ConsoleButton(i+1, representation, new BuyCommand(i));
                    buyButtonMap.Add(machineButton.Option, machineButton);
                }

                System.Console.WriteLine($"[{representation} {attack}/{health}] - [{description}]");
            }

            System.Console.WriteLine("\n\n=================================== OPTIONS ===================================");
            foreach (var key in buyButtonMap.Keys)
            {
                buyButtonMap.TryGetValue(key, out var button);
                button?.Draw();
            }
            
            int option = Int32.Parse(System.Console.ReadLine());
            buyButtonMap.TryGetValue(option, out var chosenButton);

            if (chosenButton is not null)
                await chosenButton.Execute();
        }

        public async Task DrawMachineAssignAndAwait()
        {
            System.Console.Clear();
            System.Console.WriteLine($"=================================== STORE ===================================");

            System.Console.WriteLine("\nYour team:");

            var team = GameMatch.GetInstance().PlayerTeam;
            var spotsMap = new Dictionary<int, ConsoleButton>();

            for (int i = 0; i < team.Length; i++)
            {
                var machine = team[i];

                if (machine is null)
                {
                    var spotButton = new ConsoleButton(i+1, "Place it here.", new AssignCommand(i));
                    spotsMap.Add(spotButton.Option, spotButton);
                }

                string representation = machine?.Name ?? "[empty]";
                System.Console.Write($"{representation}\t");
            }

            System.Console.WriteLine("\n\n=================================== OPTIONS ===================================");
            foreach (var key in spotsMap.Keys)
            {
                spotsMap.TryGetValue(key, out var button);
                button?.Draw();
            }
            
            int option = Int32.Parse(System.Console.ReadLine());
            spotsMap.TryGetValue(option, out var chosenButton);

            if (chosenButton is not null)
                await chosenButton.Execute();
        }

        public async Task DrawSellOptionAndAwait()
        {
            System.Console.Clear();
            System.Console.WriteLine($"=================================== STORE ===================================");

            System.Console.WriteLine("\nYour team:");

            var team = GameMatch.GetInstance().PlayerTeam;
            for (int i = 0; i < team.Length; i++)
            {
                string representation = team[i]?.Name ?? "empty";
                string description = team[i]?.Description ?? "no special ability";
                int attack = team[i]?.Attack ?? 0;
                int health = team[i]?.Health ?? 0;

                if (team[i] is not null)
                {
                    var machineButton = new ConsoleButton(i+1, representation, new SellCommand(i));
                    sellButtonMap.Add(machineButton.Option, machineButton);
                }

                System.Console.WriteLine($"[{representation} {attack}/{health}] - [{description}]");
            }

            System.Console.WriteLine("\n\n=================================== OPTIONS ===================================");
            foreach (var key in sellButtonMap.Keys)
            {
                sellButtonMap.TryGetValue(key, out var button);
                button?.Draw();
            }
            
            int option = Int32.Parse(System.Console.ReadLine());
            sellButtonMap.TryGetValue(option, out var chosenButton);

            if (chosenButton is not null)
                await chosenButton.Execute();
        }
    }
}