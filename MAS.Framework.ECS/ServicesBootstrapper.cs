using MAS.Framework.Core;
using MAS.Services.ECS;

namespace MAS.Framework.ECS
{
    public class ServicesBootstrapper : IServicesBootstrapper
    {
        public void Bootstrap(IServiceRegistrar registrar)
        {
            registrar.RegisterSingleton<IEntityContainer, EntityContainer>();
        }
    }
}