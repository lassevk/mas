using System.Diagnostics;

using MAS.Framework.Core;
using MAS.Services.Application;
using MAS.Services.Logging;
using MAS.Services.SystemEnvironment;

namespace MAS.Services.Core
{
    public class ServicesBootstrapper : IServicesBootstrapper
    {
        public void Bootstrap(IServiceRegistrar registrar)
        {
            registrar.Register<ITextLogFormatter, TextLogFormatter>();
            registrar.RegisterSingleton<IClock, SystemClock>();
            registrar.RegisterSingleton<IApplicationOptions, ApplicationOptions>();
            registrar.RegisterSingleton<ILogger, Logger>();

            if (Debugger.IsAttached)
                registrar.RegisterSingleton<ILogDestination, DebugLogDestination>();
        }
    }
}