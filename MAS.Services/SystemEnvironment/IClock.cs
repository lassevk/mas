using System;

using JetBrains.Annotations;

namespace MAS.Services.SystemEnvironment
{
    [PublicAPI]
    public interface IClock
    {
        DateTime Now();
    }
}
