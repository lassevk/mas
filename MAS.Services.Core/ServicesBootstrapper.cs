using System.Diagnostics;

using JetBrains.Annotations;

using MAS.Framework.Core;

namespace MAS.Services.Core
{
    [PublicAPI]
    public class ServicesBootstrapper : IServicesBootstrapper
    {
        public void Bootstrap([NotNull] IServiceRegistrar registrar)
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