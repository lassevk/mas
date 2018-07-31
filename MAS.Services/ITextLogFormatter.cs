﻿using System.Collections.Generic;

using JetBrains.Annotations;

namespace MAS.Services
{
    [PublicAPI]
    public interface ITextLogFormatter
    {
        [NotNull, ItemNotNull]
        IEnumerable<string> Format(LogEntryType type, [NotNull] string message);
    }
}