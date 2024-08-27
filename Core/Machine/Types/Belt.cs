using SuperAutoMachines.Core.Battle;
using SuperAutoMachines.Core.Match;

namespace SuperAutoMachines.Core.Machine.Types
{
    public class Belt : BaseMachine
    {
        public Belt() : base()
        {
            Name = "Belt";
            Attack = 3;
            Health = 1;
            Tier = 1;
        }

        public override void OnAttack(Fighter enemy) { }

        public override void OnBattle() { }

        public override void OnDeath() { }

        public override void OnPrep() { }

        public override void OnSell()
        {
            GameMatch.GetInstance().Coins += 2;
        }

        public override void OnTurn() { }
    }
}