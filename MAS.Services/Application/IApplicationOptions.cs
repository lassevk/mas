namespace MAS.Services.Application
{
    public interface IApplicationOptions
    {
        bool IsDebug { get; }

        bool IsVerbose { get; }
    }
}
