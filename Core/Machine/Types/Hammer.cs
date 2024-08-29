using SuperAutoMachines.Core.Battle;
using SuperAutoMachines.Core.Match;

namespace SuperAutoMachines.Core.Machine.Types
{
    public class Hammer : BaseMachine
    {
        public Hammer(bool isCpu) : base(isCpu)
        {
            Name = "Hammer";
            Description = "Raises Health of each machine on sale by 1 when sold.";
            Attack = 2;
            Health = 3;
            Tier = 1;
        }

        public override void OnAttack(Fighter enemy) { }

        public override void OnBattle() { }

        public override void OnBuy() { }

        public override void OnDeath() { }

        public override void OnPrep() { }

        public override void OnSell()
        {
            var machines = GameStore.GetInstance().MachinesOnSale;
            foreach (var machine in machines)
                machine.Health++;
        }

        public override void OnTurn() { }
    }
}