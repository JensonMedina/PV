namespace Application.Interfaces
{
    public interface ILoggerApp
    {
        void LogInfo(string context, string message, string? additionalData = null);
        void LogError(string context, string message, string? additionalData = null);
        void LogWarning(string context, string message, string? additionalData = null);
    }
}
