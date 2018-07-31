using JetBrains.Annotations;

namespace MAS.Framework.Core
{
    public interface IServiceResolver
    {
        [NotNull]
        T Resolve<T>()
            where T: class;
    }
}