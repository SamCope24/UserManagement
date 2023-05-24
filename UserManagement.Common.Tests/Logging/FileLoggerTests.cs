using UserManagement.Common.Logging;

namespace UserManagement.Common.Tests.Logging;

public class FileLoggerTests
{
    [Fact]
    public void Constructor_CalledWithNullFileWrapper_ThrowsArgumentNullException()
    {
        FluentActions.Invoking(() => CreateFileLoggerWith(fileWrapper: null!))
            .Should()
            .Throw<ArgumentNullException>()
            .WithParameterName("fileWrapper");
    }

    private static FileLogger CreateFileLoggerWith(IFileWrapper fileWrapper)
        => new(fileWrapper);

    [Fact]
    public void Log_AfterCalling_InvokesFileWrapperWriteMethodOnceWithLogText()
    {
        const string LogText = "Logging some cool stuff";
        var mockFileWrapper = MockFileWrapper();
        var fileLogger = CreateFileLoggerWith(mockFileWrapper.Object);

        fileLogger.Log(LogText);

        mockFileWrapper.Verify(x => x.Write(It.Is<string>(s => s.Contains(LogText))), Times.Once);
    }

    private static Mock<IFileWrapper> MockFileWrapper() => new();

    [Fact]
    public void LogError_AfterCalling_InvokesFileWrapperWriteMethodOnceWithExceptionMessageDetail()
    {
        var exception = new Exception("A nasty exception");
        var mockFileWrapper = MockFileWrapper();
        var fileLogger = CreateFileLoggerWith(mockFileWrapper.Object);

        fileLogger.LogError(exception);

        mockFileWrapper.Verify(x => x.Write(It.Is<string>(s => s.Contains(exception.Message))), Times.Once);
    }
}