using SuperAutoMachines.Core.Battle;
using SuperAutoMachines.Core.Match;

namespace SuperAutoMachines.Core.Machine.Types.TierTwo
{
    public class GasOven : BaseMachine
    {
        public GasOven(bool isCpu) : base(isCpu)
        {
            Name = "Gas Oven";
            Description = "At the beggining of the preparation phase, gain 1 coin.";
            Attack = 1;
            Health = 3;
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
        }

        public override void OnPrep()
        {
            GameMatch.GetInstance().Coins++;
        }

        public override void OnSell()
        {
        }

        public override void OnTurn()
        {
        }
    }
}