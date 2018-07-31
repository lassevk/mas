namespace MAS.Game.Core.Effects.Creatures
{
    public class DamageEffect : IToughnessAdjustmentEffect
    {
        public DamageEffect(int amount)
        {
            Amount = amount;
        }

        public int Amount { get; }

        int IToughnessAdjustmentEffect.Adjustment => -Amount;
    }
}
