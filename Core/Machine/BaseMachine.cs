using SuperAutoMachines.Core.Battle;
using SuperAutoMachines.Core.Match;

namespace SuperAutoMachines.Core.Machine
{
    public abstract class BaseMachine
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Attack { get; set; }
        public int Health { get; set; }
        public int Tier { get; set; }
        public int Level { get; set; }
        public int Experience { get; set; }
        public bool IsCpuMachine { get; set; }

        public BaseMachine(bool isCpu)
        {
            Name = "Not assigned";
            Description = "Not assigned";
            Level = 1;
            Experience = 1;
            IsCpuMachine = isCpu;
        }

        public void RaiseExperienceTo(int exp)
        {
            if (Level == 3)
                return;

            if (exp > 6)
                exp = 6;
            
            Experience = exp;
            Level = (Experience / 3) + 1;
        }

        public abstract void OnPrep();

        public abstract void OnBuy();

        public abstract void OnSell();

        public abstract void OnBattle();

        public abstract void OnTurn();

        public abstract void OnAttack(Fighter enemy);

        public abstract void OnDeath();
    }
}