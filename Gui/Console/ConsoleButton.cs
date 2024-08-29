
namespace SuperAutoMachines.Gui.Console
{
    public class ConsoleButton : IButton
    {
        public int Option { get; set; }
        public string Text { get; set; }
        public ICommand? Command { get; set; }

        public ConsoleButton(
                int option,
                string text,
                ICommand? command = null)
        {
            Option = option;
            Text = text;
            Command = command;
        }

        public void Draw()
        {
            System.Console.WriteLine($"{Option}) {Text}");
        }

        public async Task Execute()
        {
            if (Command is null)
                throw new InvalidOperationException("Command not set to button!");
            
            await Command.Execute();
        }
    }
}