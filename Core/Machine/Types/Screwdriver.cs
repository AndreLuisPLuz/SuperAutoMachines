using SuperAutoMachines.Core.Battle;

namespace SuperAutoMachines.Core.Machine.Types
{
    public class Screwdriver : Machine
    {
        public Screwdriver() : base()
        {
            Name = "Screwdriver";
            Attack = 2;
            Health = 3;
            Tier = 1;
        }

        public override void OnAttack(Fighter enemy) { }

        public override void OnBattle() { }

        public override void OnDeath() { }

        public override void OnPrep() { }

        public override void OnTurn() { }
    }
}