using System.Collections.Generic;

using JetBrains.Annotations;

namespace MAS.Services.Logging
{
    public interface ITextLogFormatter
    {
        [NotNull, ItemNotNull]
        IEnumerable<string> Format(LogEntryType type, [NotNull] string message);
    }
}