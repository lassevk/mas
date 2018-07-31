using System;
using System.Diagnostics;

using MAS.App.Core;
using MAS.Framework.Core;
using MAS.Services.Application;
using MAS.Services.Logging;

namespace MAS.App.Console
{
    static class Program
    {
        static void Main()
        {
            IServiceContainer container = new AppBootStrapper().CreateApplicationContainer();

            try
            {
                container.Bootstrap<ConsoleBootstrapper>();

                var logger = container.Resolve<ILogger>();
                try
                {
                    container.Resolve<IApplicationEntryPoint>().Execute();
                }
                catch (Exception ex) when (!Debugger.IsAttached)
                {
                    logger.Error($"{ex.GetType().Name}: {ex.Message}");

                    if (ex.StackTrace != null)
                        logger.Error(ex.StackTrace);

                    Environment.Exit(1);
                }
            }
            catch (Exception ex) when (!Debugger.IsAttached)
            {
                System.Console.WriteLine($"{ex.GetType().Name}: {ex.Message}");

                if (ex.StackTrace != null)
                    System.Console.WriteLine(ex.StackTrace);

                Environment.Exit(1);
            }
        }
    }
}