using JetBrains.Annotations;

namespace MAS.Game.Core.Components.Cards.Creatures
{
    public class StaticCreatureTypeComponent : ReferenceTypeComponentBase<string>
    {
        public StaticCreatureTypeComponent([NotNull] string value)
            : base(value)
        {
        }
    }
}