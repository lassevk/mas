using JetBrains.Annotations;

namespace MAS.Framework.Core
{
    [PublicAPI]
    public interface IServiceContainer : IServiceRegistrar, IServiceResolver
    {
    }
}