using System;
using System.Diagnostics;

using JetBrains.Annotations;

using MAS.Services.Application;
using MAS.Services.Game;
using MAS.Services.Logging;

namespace MAS.App.Core
{
    [UsedImplicitly]
    internal class ApplicationEntryPoint : IApplicationEntryPoint
    {
        [NotNull]
        private readonly ILogger _Logger;

        [NotNull]
        private readonly IGameEngine _GameEngine;

        public ApplicationEntryPoint([NotNull] ILogger logger, [NotNull] IGameEngine gameEngine)
        {
            _Logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _GameEngine = gameEngine ?? throw new ArgumentNullException(nameof(gameEngine));
        }

        public void Execute()
        {
            Stopwatch sw = Stopwatch.StartNew();
            _Logger.Verbose("Application starting");
            try
            {
                _GameEngine.Run();
                
                sw.Stop();
                _Logger.Verbose($"Application terminated successfully after {sw.ElapsedMilliseconds}ms");
            }
            catch (Exception)
            {
                sw.Stop();
                _Logger.Verbose($"Application terminated with an error after {sw.ElapsedMilliseconds}ms");

                throw;
            }
        }
    }
}
