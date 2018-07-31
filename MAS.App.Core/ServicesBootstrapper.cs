using JetBrains.Annotations;

using MAS.Framework.Core;
using MAS.Services;

namespace MAS.App.Core
{
    [PublicAPI]
    public class ServicesBootstrapper : IServicesBootstrapper
    {
        public void Bootstrap([NotNull] IServiceRegistrar registrar)
        {
            registrar.Register<IApplicationEntryPoint, ApplicationEntryPoint>();
        }
    }
}