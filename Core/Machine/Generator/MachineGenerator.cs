namespace SuperAutoMachines.Core.Battle.Generator
{
    public class MachineGenerator
    {
        private static Generator generator = new TierOneGenerator();

        public static Generator Tier(GeneratorTier tier)
        {
            switch (tier)
            {
                case GeneratorTier.ONE:
                    generator = new TierOneGenerator();
                    break;
                case GeneratorTier.TWO:
                    generator = new TierTwoGenerator();
                    break;
                case GeneratorTier.THREE:
                    generator = new TierThreeGenerator();
                    break;
                case GeneratorTier.FOUR:
                    generator = new TierFourGenerator();
                    break;
                case GeneratorTier.FIVE:
                    generator = new TierFiveGenerator();
                    break;
                case GeneratorTier.SIX:
                    generator = new TierSixGenerator();
                    break;
            }

            return generator;
        }
    }

    public enum GeneratorTier
    {
        ONE = 1,
        TWO,
        THREE,
        FOUR,
        FIVE,
        SIX
    }
}