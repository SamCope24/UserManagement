namespace UserManagement.Common.Logging;

public interface IFileWrapper
{
    public void Write(string message);
    public string Read();
}