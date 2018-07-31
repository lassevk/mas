using JetBrains.Annotations;

namespace MAS.Services.Application
{
    [PublicAPI]
    public interface IApplicationOptions
    {
        bool IsDebug { get; }

        bool IsVerbose { get; }
    }
}
