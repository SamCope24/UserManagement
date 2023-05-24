namespace UserManagement.Common.Logging;

public class FileLogger : ILogger
{
    private readonly IFileWrapper _fileWrapper;

    public FileLogger(IFileWrapper fileWrapper)
    {
        _fileWrapper = fileWrapper ?? throw new ArgumentNullException(nameof(fileWrapper));
    }

    public void Log(string message) => LogEntry(message);

    public void LogError(Exception ex) => LogEntry($"ERROR: {ex.Message}");

    private void LogEntry(string message) => _fileWrapper.Write($"{DateTime.Now}: {message};");
}
