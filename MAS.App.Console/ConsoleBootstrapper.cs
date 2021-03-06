﻿using MAS.Framework.Core;
using MAS.Services.Logging;

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