using SuperAutoMachines.Core.Machine;

namespace SuperAutoMachines.Core.Battle
{
    public class Fighter
    {
        private readonly Machine.Machine machine;
        public int CurrentAttack { get; set; }
        public int CurrentHealth { get; set; }
        public bool IsAlive { get; set; } = true;
        public string Name => machine.Name;

        public Fighter(Machine.Machine machine)
        {
            this.machine = machine;

            CurrentAttack = machine.Attack;
            CurrentHealth = machine.Health;
        }

        public void BattleStart() => machine.OnBattle();

        public void TakeTurn() => machine.OnTurn();

        public void Attack(Fighter enemy)
        {
            CurrentHealth -= enemy.CurrentAttack;
            machine.OnAttack(enemy);

            if (CurrentHealth <= 0)
                Die();
        }

        private void Die()
        {
            machine.OnDeath();
            IsAlive = false;
        }
    }
}