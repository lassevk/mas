using System;

using JetBrains.Annotations;

namespace MAS.Services.Core
{
    public class DebugLogDestination : ILogDestination
    {
        [NotNull]
        private readonly ITextLogFormatter _TextLogFormatter;

        public DebugLogDestination([NotNull] ITextLogFormatter textLogFormatter)
        {
            _TextLogFormatter = textLogFormatter ?? throw new ArgumentNullException(nameof(textLogFormatter));
        }

        private void Output(LogEntryType type, [NotNull] string message)
        {
            foreach (var line in _TextLogFormatter.Format(type, message))
                System.Diagnostics.Debug.WriteLine(line);
        }

        public void Message(string message) => Output(LogEntryType.Message, message);
        public void Error(string message) => Output(LogEntryType.Error, message);
        public void Warning(string message) => Output(LogEntryType.Warning, message);
        public void Verbose(string message) => Output(LogEntryType.Verbose, message);
        public void Debug(string message) => Output(LogEntryType.Debug, message);
    }
}