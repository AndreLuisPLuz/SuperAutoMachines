namespace SuperAutoMachines.Core.Battle
{
    public class BattleEvent
    {
        public string Header;
        public Fighter[] BlueTeam;
        public Fighter[] RedTeam;
        public Queue<string> ActionsTaken = new();

        public BattleEvent(string header)
        {
            Header = header;
            BlueTeam = GameBattle.GetInstance().BlueTeam.ToArray();
            RedTeam = GameBattle.GetInstance().RedTeam.ToArray();
        }

        public void RegisterAction(string newAction)
        {
            ActionsTaken.Enqueue(newAction);
        }
    }
}