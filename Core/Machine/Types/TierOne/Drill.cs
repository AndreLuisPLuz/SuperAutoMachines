using SuperAutoMachines.Core.Battle;

namespace SuperAutoMachines.Core.Machine.Types.TierOne
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
                    .ToArray();

            if (allies.Length != 0)
            {
                var randomIndex = Random.Shared.Next(0, allies.Length - 1);
                var ally = team.ToArray()[randomIndex];

                ally.CurrentAttack += 2;
                ally.CurrentHealth += 1;

                GameBattle.GetInstance()
                        .CurrentEvent
                        .RegisterAction(
                            $"Drill raised {ally.Name}'s attack and health before his defeat!");
            }

        }

        public override void OnPrep() { }

        public override void OnSell() { }

        public override void OnTurn() { }
    }
}