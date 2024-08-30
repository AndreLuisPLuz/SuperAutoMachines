
using SuperAutoMachines.Core.Battle;
using SuperAutoMachines.Gui.Console.Battle.Commands;

namespace SuperAutoMachines.Gui.Console.Battle
{
    public class BattleGuiConsole : IBattleGui
    {
        private readonly MatchGotoCommand command = new();

        public async Task DrawBattleAndAwait()
        {
            System.Console.Clear();
            System.Console.WriteLine("=================================== BATTLE ===================================");

            var battleEvents = GameBattle.GetInstance().Events;
            while (battleEvents.Count > 0)
            {
                var e = battleEvents.Dequeue();
                var blueTeam = e.BlueTeam;
                var redTeam = e.RedTeam.Reverse();

                System.Console.Write("\n\nBlue team: ");
                foreach (var fighter in blueTeam)
                    System.Console.Write($"[{fighter.Name} {fighter.CurrentAttack}/{fighter.CurrentHealth}] ");

                System.Console.Write("\n\nRed team: ");
                foreach (var fighter in redTeam)
                    System.Console.Write($"[{fighter.Name} {fighter.CurrentAttack}/{fighter.CurrentHealth}] ");

                System.Console.WriteLine("\n");                
                foreach (var action in e.ActionsTaken)
                    System.Console.WriteLine(action);
            }

            System.Console.WriteLine("\n\nPress any key...");
            System.Console.ReadLine();

            await command.Execute();
        }
    }
}