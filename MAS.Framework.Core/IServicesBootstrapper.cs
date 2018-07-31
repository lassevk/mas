using JetBrains.Annotations;

namespace MAS.Framework.Core
{
    public interface IServicesBootstrapper
    {
        void Bootstrap([NotNull] IServiceRegistrar registrar);
    }
}
