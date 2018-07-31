using System;

using JetBrains.Annotations;

namespace MAS.Services
{
    [PublicAPI]
    public interface IClock
    {
        DateTime Now();
    }
}
