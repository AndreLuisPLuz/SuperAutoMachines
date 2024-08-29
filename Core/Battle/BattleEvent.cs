namespace SuperAutoMachines.Core.Battle
{
    public class BattleEvent
    {
        public Queue<string> actionsTaken = new();

        public void RegisterAction(string newAction)
        {
            actionsTaken.Enqueue(newAction);
        }
    }
}