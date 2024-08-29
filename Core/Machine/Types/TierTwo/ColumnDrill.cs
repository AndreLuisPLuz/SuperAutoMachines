using SuperAutoMachines.Core.Battle;

namespace SuperAutoMachines.Core.Machine.Types.TierTwo
{
    public class ColumnDrill : BaseMachine
    {
        public ColumnDrill(bool isCpu) : base(isCpu)
        {
            Name = "Column Drill";
            Description = "Causes 1 damage to the ally behind when attacking.";
            Attack = 3;
            Health = 5;
            Tier = 2;
        }

        public override void OnAttack(Fighter enemy)
        {
            var team = IsCpuMachine
                ? GameBattle.GetInstance().RedTeam
                : GameBattle.GetInstance().BlueTeam;
            
            var ally = team.SkipLast(1).Last();
            
            if (ally is not null)
                ally.CurrentHealth -= 1;
        }

        public override void OnBattle()
        {
        }

        public override void OnBuy()
        {
        }

        public override void OnDeath()
        {
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