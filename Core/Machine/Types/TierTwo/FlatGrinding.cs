using SuperAutoMachines.Core.Battle;

namespace SuperAutoMachines.Core.Machine.Types.TierTwo
{
    public class FlatGrinder : BaseMachine
    {
        public FlatGrinder(bool isCpu) : base(isCpu)
        {
            Name = "Flat Grinder";
            Description = "Raises Attack and Health of its two rear allies by 1/1 when defeated.";
            Attack = 4;
            Health = 2;
            Tier = 2;
        }

        public override void OnAttack(Fighter enemy)
        {
        }

        public override void OnBattle()
        {
        }

        public override void OnBuy()
        {
        }

        public override void OnDeath()
        {
            var team = IsCpuMachine
                ? GameBattle.GetInstance().RedTeam
                : GameBattle.GetInstance().BlueTeam;
            
            var rearAllies = team.SkipLast(1).TakeLast(2);
            foreach(var ally in rearAllies)
            {
                ally.CurrentAttack++;
                ally.CurrentHealth++;
                GameBattle.GetInstance()
                        .CurrentEvent
                        .RegisterAction($"Flat Grinder raises the Attack and Health of {ally.Name} before being defeated!");
            }
        }

        public override void OnPrep()
        {
        }

        public override void OnSell()
        {
        }

        public override void OnTurn()
        {
        }
    }
}