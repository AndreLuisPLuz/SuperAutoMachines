using SuperAutoMachines.Core.Battle;
using SuperAutoMachines.Core.Match;

namespace SuperAutoMachines.Core.Machine.Types
{
    public class Belt : BaseMachine
    {
        public Belt(bool isCpu) : base(isCpu)
        {
            Name = "Belt";
            Description = "Gives 1 additional coin when sold.";
            Attack = 3;
            Health = 1;
            Tier = 1;
        }

        public override void OnAttack(Fighter enemy) { }

        public override void OnBattle() { }

        public override void OnBuy() { }

        public override void OnDeath() { }

        public override void OnPrep() { }

        public override void OnSell()
        {
            GameMatch.GetInstance().Coins += 1;
        }

        public override void OnTurn() { }
    }
}