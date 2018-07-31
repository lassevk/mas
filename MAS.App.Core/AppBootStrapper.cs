using JetBrains.Annotations;

using MAS.Framework.Container;
using MAS.Framework.Core;

namespace MAS.App.Core
{
    [PublicAPI]
    public class AppBootStrapper
    {
        [NotNull]
        public IServiceContainer CreateApplicationContainer()
        {
            IServiceContainer container = new ContainerFactory().Create();

            container.Bootstrap<ServicesBootstrapper>()
               .Bootstrap<Services.Core.ServicesBootstrapper>()
               .Bootstrap<Framework.ECS.ServicesBootstrapper>();

            return container;
        }
    }
}