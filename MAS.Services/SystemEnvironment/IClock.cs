using System;

namespace MAS.Services.SystemEnvironment
{
    public interface IClock
    {
        DateTime Now();
    }
}
