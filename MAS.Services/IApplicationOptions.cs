using JetBrains.Annotations;

namespace MAS.Services
{
    [PublicAPI]
    public interface IApplicationOptions
    {
        bool IsDebug { get; }

        bool IsVerbose { get; }
    }
}
