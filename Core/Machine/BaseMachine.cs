using SuperAutoMachines.Core.Battle;
using SuperAutoMachines.Core.Match;

namespace SuperAutoMachines.Core.Machine
{
    public abstract class BaseMachine
    {
        public string Name { get; set; }
        public int Attack { get; set; }
        public int Health { get; set; }
        public int Tier { get; set; }
        public int Level { get; set; }
        public int Experience { get; set; }

        public BaseMachine()
        {
            Name = "Not assigned";
            Level = 1;
            Experience = 1;
        }

        public abstract void OnPrep();

        public virtual void OnSell()
        {
            GameMatch.GetInstance().Coins++;
        }

        public abstract void OnBattle();

        public abstract void OnTurn();

        public abstract void OnAttack(Fighter enemy);

        public abstract void OnDeath();
    }
}