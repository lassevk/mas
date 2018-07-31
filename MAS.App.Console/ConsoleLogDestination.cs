using System;

using JetBrains.Annotations;

using MAS.Services.Application;
using MAS.Services.Logging;

namespace MAS.App.Console
{
    internal class ConsoleLogDestination : ILogDestination
    {
        [NotNull]
        private readonly ITextLogFormatter _TextLogFormatter;

        [NotNull]
        private readonly IApplicationOptions _Options;

        public ConsoleLogDestination([NotNull] ITextLogFormatter textLogFormatter, [NotNull] IApplicationOptions options)
        {
            _TextLogFormatter = textLogFormatter ?? throw new ArgumentNullException(nameof(textLogFormatter));
            _Options = options ?? throw new ArgumentNullException(nameof(options));
        }

        public void Message(string message)
        {
            foreach (var line in _TextLogFormatter.Format(LogEntryType.Message, message))
                System.Console.Out.WriteLine(line);
        }

        public void Error(string message)
        {
            foreach (var line in _TextLogFormatter.Format(LogEntryType.Error, message))
                System.Console.Error.WriteLine(line);
        }

        public void Warning(string message)
        {
            foreach (var line in _TextLogFormatter.Format(LogEntryType.Warning, message))
                System.Console.Error.WriteLine(line);
        }

        public void Verbose(string message)
        {
            if (_Options.IsVerbose)
                foreach (var line in _TextLogFormatter.Format(LogEntryType.Verbose, message))
                    System.Console.Out.WriteLine(line);
        }

        public void Debug(string message)
        {
            if (_Options.IsDebug)
                foreach (var line in _TextLogFormatter.Format(LogEntryType.Debug, message))
                    System.Console.Out.WriteLine(line);
        }
    }
}