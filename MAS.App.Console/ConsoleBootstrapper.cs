using MAS.Framework.Core;
using MAS.Services;

namespace MAS.App.Console
{
    internal class ConsoleBootstrapper : IServicesBootstrapper
    {
        public void Bootstrap(IServiceRegistrar registrar)
        {
            registrar.Register<ILogDestination, ConsoleLogDestination>();
        }
    }
}