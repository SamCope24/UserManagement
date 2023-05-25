using System.IO.Abstractions;
using System.Text;

namespace UserManagement.Common.Logging;

public class FileRepository : IFileWrapper
{
    private readonly IFileSystem _fileSystem;
    private readonly string _filePath;

    public FileRepository(IFileSystem fileSystem, string filePath)
    {
        _fileSystem = fileSystem ?? throw new ArgumentNullException(nameof(fileSystem));

        if (string.IsNullOrWhiteSpace(filePath))
        {
            throw new ArgumentException("File path must be specified", nameof(filePath));
        }

        _filePath = filePath;
    }

    public string Read() => _fileSystem.File.ReadAllText(_filePath, Encoding.UTF8);
    public void Write(string message) => _fileSystem.File.AppendAllText(_filePath, message);
}