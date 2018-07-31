using JetBrains.Annotations;

namespace MAS.Game.Core.Components.Cards
{
    public class StaticCastingCostComponent : ReferenceTypeComponentBase<string>
    {
        public StaticCastingCostComponent([NotNull] string value)
            : base(value)
        {
        }
    }
}