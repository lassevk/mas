using JetBrains.Annotations;

namespace MAS.Game.Core.Components
{
    public abstract class SingletonComponentBase<T>
        where T : SingletonComponentBase<T>, new()
    {
        [NotNull]
        public static T Instance { get; } = new T();

        public override string ToString() => GetType().Name;
    }
}