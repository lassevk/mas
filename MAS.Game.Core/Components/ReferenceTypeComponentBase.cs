using System;

using JetBrains.Annotations;

namespace MAS.Game.Core.Components
{
    public abstract class ReferenceTypeComponentBase<T>
        where T: class
    {
        protected ReferenceTypeComponentBase([NotNull] T value)
        {
            Value = value ?? throw new ArgumentNullException(nameof(value));
        }

        [NotNull]
        public T Value { get; }

        public override string ToString() => $"{GetType().Name} = {Value}";
    }
}