using JetBrains.Annotations;

namespace MAS.Game.Core.Components.Cards
{
    public class StaticNameComponent : ReferenceTypeComponentBase<string>
    {
        public StaticNameComponent([NotNull] string value)
            : base(value)
        {
        }
    }
}
