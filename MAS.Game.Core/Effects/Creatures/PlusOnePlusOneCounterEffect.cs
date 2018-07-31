namespace MAS.Game.Core.Effects.Creatures
{
    public class PlusOnePlusOneCounterEffect : IPowerAdjustmentEffect, IToughnessAdjustmentEffect
    {
        int IPowerAdjustmentEffect.Adjustment => 1;
        int IToughnessAdjustmentEffect.Adjustment => 1;
    }
}
