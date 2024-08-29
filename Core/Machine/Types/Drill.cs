using SuperAutoMachines.Core.Battle;

namespace SuperAutoMachines.Core.Machine.Types
{
    public class Drill : BaseMachine
    {
        public Drill(bool isCpu) : base(isCpu)
        {
            Name = "Drill";
            Description = "Raises Attack and Health of a random ally by 2/1 when defeated. Lasts as long as the battle goes on.";
            Attack = 2;
            Health = 1;
            Tier = 1;
        }

        public override void OnAttack(Fighter enemy) { }

        public override void OnBattle() { }

        public override void OnBuy() { }

        public override void OnDeath()
        {
            var team = IsCpuMachine
                ? GameBattle.GetInstance().RedTeam
                : GameBattle.GetInstance().BlueTeam;

            var allies = team.Select(a => a.Machine)
                    .Except([this])
                    .ToArray();

            if (allies.Length != 0)
            {
                var randomIndex = Random.Shared.Next(0, allies.Length - 1);
                allies[randomIndex].Attack += 2;
                allies[randomIndex].Health += 1;
            }
        }

        public override void OnPrep() { }

        public override void OnSell() { }

        public override void OnTurn() { }
    }
}