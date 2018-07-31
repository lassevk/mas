using JetBrains.Annotations;

using MAS.Framework.Core;
using MAS.Services.ECS;

namespace MAS.Framework.ECS
{
    [PublicAPI]
    public class ServicesBootstrapper : IServicesBootstrapper
    {
        public void Bootstrap([NotNull] IServiceRegistrar registrar)
        {
            registrar.RegisterSingleton<IEntityContainer, EntityContainer>();
        }
    }
}