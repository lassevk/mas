using System;
using System.Diagnostics;
using System.Threading;

using JetBrains.Annotations;

using MAS.Services.Application;
using MAS.Services.Logging;

namespace MAS.App.Core
{
    [UsedImplicitly]
    internal class ApplicationEntryPoint : IApplicationEntryPoint
    {
        [NotNull]
        private readonly ILogger _Logger;

        public ApplicationEntryPoint([NotNull] ILogger logger)
        {
            _Logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public void Execute()
        {
            Stopwatch sw = Stopwatch.StartNew();

            _Logger.Verbose("Application starting");
            Thread.Sleep(1000);

            sw.Stop();
            _Logger.Verbose($"Application terminated successfully after {sw.ElapsedMilliseconds}ms");
        }
    }
}
