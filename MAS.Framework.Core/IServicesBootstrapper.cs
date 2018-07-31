using JetBrains.Annotations;

namespace MAS.Framework.Core
{
    [PublicAPI]
    public interface IServicesBootstrapper
    {
        void Bootstrap([NotNull] IServiceRegistrar registrar);
    }
}
