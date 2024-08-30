using SuperAutoMachines.Core.Battle;

namespace SuperAutoMachines.Core.Machine.Types.TierTwo
{
    public class FlatGrindind : BaseMachine
    {
        public FlatGrindind(bool isCpu) : base(isCpu)
        {
            Name = "Flat Grinding";
            Description = "Raises Attack and Health of its two rear allies by 1/1 on death.";
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
                ? GameBattle.NextRound().RedTeam
                : GameBattle.NextRound().BlueTeam;
            
            var rearAllies = team.SkipLast(1).TakeLast(2);
            foreach(var ally in rearAllies)
            {
                ally.CurrentAttack++;
                ally.CurrentHealth++;
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