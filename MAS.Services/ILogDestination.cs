﻿using JetBrains.Annotations;

namespace MAS.Services
{
    [PublicAPI]
    public interface ILogDestination
    {
        void Message([NotNull] string message);
        void Error([NotNull] string message);
        void Warning([NotNull] string message);
        void Verbose([NotNull] string message);
        void Debug([NotNull] string message);
    }
}