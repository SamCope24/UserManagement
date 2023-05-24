
namespace UserManagement.Common.Logging;

public class ConsoleLogger : ILogger
{
    public void Log(string message) => Console.WriteLine(message);
    public void LogError(Exception ex) => Console.WriteLine($"ERROR: {ex}");
}