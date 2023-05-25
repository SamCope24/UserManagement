namespace UserManagement.Common.Logging;

public interface ILogger
{
    void Log(string message);
    void LogError(Exception ex);
}