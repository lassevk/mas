using System;
using System.Collections.Generic;
using System.Linq;

using JetBrains.Annotations;

namespace MAS.Services.Core
{
    internal class Logger : ILogger
    {
        [NotNull, ItemNotNull]
        private readonly List<ILogDestination> _Destinations;

        public Logger([NotNull, ItemNotNull] IEnumerable<ILogDestination> destinations)
        {
            _Destinations = (destinations ?? throw new ArgumentNullException(nameof(destinations))).ToList();
        }

        public void Message(string message)
        {
            foreach (ILogDestination destination in _Destinations)
                destination.Message(message);
        }

        public void Error(string message)
        {
            foreach (ILogDestination destination in _Destinations)
                destination.Error(message);
        }

        public void Warning(string message)
        {
            foreach (ILogDestination destination in _Destinations)
                destination.Warning(message);
        }

        public void Verbose(string message)
        {
            foreach (ILogDestination destination in _Destinations)
                destination.Verbose(message);
        }

        public void Debug(string message)
        {
            foreach (ILogDestination destination in _Destinations)
                destination.Debug(message);
        }
    }
}