using JetBrains.Annotations;

using MAS.Framework.Core;

namespace MAS.Framework.ECS
{
    [PublicAPI]
    public class ServicesBootstrapper : IServicesBootstrapper
    {
        public void Bootstrap([NotNull] IServiceRegistrar registrar)
        {
        }
    }
}