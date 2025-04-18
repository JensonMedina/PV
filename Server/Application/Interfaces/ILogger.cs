namespace Application.Common.Interfaces
{
    public interface ILogger
    {
        void LogInfo(string context, string message, string? additionalData = null);
        void LogError(string context, string message, string? additionalData = null);
    }
}
