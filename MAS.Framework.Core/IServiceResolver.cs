using JetBrains.Annotations;

namespace MAS.Framework.Core
{
    [PublicAPI]
    public interface IServiceResolver
    {
        [NotNull]
        T Resolve<T>()
            where T: class;
    }
}