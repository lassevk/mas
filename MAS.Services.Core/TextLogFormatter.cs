using System;
using System.Collections.Generic;
using System.IO;

using JetBrains.Annotations;

using MAS.Services.Logging;
using MAS.Services.SystemEnvironment;

namespace MAS.Services.Core
{
    internal class TextLogFormatter : ITextLogFormatter
    {
        [NotNull]
        private readonly IClock _Clock;

        [NotNull]
        private static readonly Dictionary<LogEntryType, string> _LogEntryTypeNames =
            new Dictionary<LogEntryType, string>
            {
                [LogEntryType.Debug] = "DEBUG",
                [LogEntryType.Verbose] = "INFO",
                [LogEntryType.Message] = "INFO",
                [LogEntryType.Warning] = "WARN",
                [LogEntryType.Error] = "ERROR",
            };

        public TextLogFormatter([NotNull] IClock clock)
        {
            _Clock = clock ?? throw new ArgumentNullException(nameof(clock));
        }

        public IEnumerable<string> Format(LogEntryType type, string message)
        {
            using (var reader = new StringReader(message))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                    yield return $"{_Clock.Now():yyyy-MM-dd HH:mm:ss.fff} {_LogEntryTypeNames[type],-5}: {line}";
            }
        }
    }
}