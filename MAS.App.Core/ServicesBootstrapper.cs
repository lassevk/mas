using MAS.Framework.Core;
using MAS.Services.Application;

namespace MAS.App.Core
{
    public class ServicesBootstrapper : IServicesBootstrapper
    {
        public void Bootstrap(IServiceRegistrar registrar)
        {
            registrar.Register<IApplicationEntryPoint, ApplicationEntryPoint>();
        }
    }
}