namespace SuperAutoMachines.Core.Battle
{
    public class BattleEvent
    {
        public Fighter[] BlueTeam;
        public Fighter[] RedTeam;
        public Queue<string> ActionsTaken = new();

        public BattleEvent()
        {
            BlueTeam = GameBattle.GetInstance().BlueTeam.ToArray();
            RedTeam = GameBattle.GetInstance().RedTeam.ToArray();
        }

        public void RegisterAction(string newAction)
        {
            ActionsTaken.Enqueue(newAction);
        }
    }
}