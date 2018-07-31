using System;

namespace MAS.Services.Core
{
    internal class SystemClock : IClock
    {
        public DateTime Now() => DateTime.Now;
    }
}