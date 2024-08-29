using SuperAutoMachines.Core.Battle;
using SuperAutoMachines.Core.Match;

namespace SuperAutoMachines.Core.Machine.Types.TierOne
{
    public class Screwdriver : BaseMachine
    {
        public Screwdriver(bool isCpu) : base(isCpu)
        {
            Name = "Screwdriver";
            Description = "Raises Health of one random ally by 1 when sold.";
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
            var allies = GameMatch.GetInstance()
                    .PlayerTeam
                    .Where(m => m is not null)
                    .ToArray();

            if (allies.Length != 0)
            {
                var randomIndex = Random.Shared.Next(0, allies.Length - 1);
                allies[randomIndex].Health++;
            }
        }

        public override void OnTurn() { }
    }
}