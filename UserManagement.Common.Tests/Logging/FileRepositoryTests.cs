using System.IO.Abstractions;
using UserManagement.Common.Logging;

namespace UserManagement.Common.Tests.Logging;

public class FileWrapperTests
{
    [Fact]
    public void Constructor_CalledWithNullFileSystem_ThrowsArgumentNullException()
    {
        FluentActions.Invoking(() => CreateFileRepositoryWith(fileSystem: null!, AnyFilePath()))
            .Should()
            .Throw<ArgumentNullException>()
            .WithParameterName("fileSystem");
    }

    private static FileRepository CreateFileRepositoryWith(IFileSystem fileSystem, string filePath)
        => new(fileSystem, filePath);

    private static string AnyFilePath() => "c/files/file";

    [Fact]
    public void Constructor_CalledWithEmptyFilePath_ThrowsArgumentException()
    {
        FluentActions.Invoking(() => CreateFileRepositoryWith(DummyFileSystem(), filePath: string.Empty))
            .Should()
            .Throw<ArgumentException>()
            .WithParameterName("filePath")
            .WithMessage("File path must be specified*");
    }

    private static IFileSystem DummyFileSystem() => Mock.Of<IFileSystem>();

    [Fact]
    public void Constructor_CalledWithNullFilePath_ThrowsArgumentException()
    {
        FluentActions.Invoking(() => CreateFileRepositoryWith(DummyFileSystem(), filePath: null!))
            .Should()
            .Throw<ArgumentException>()
            .WithParameterName("filePath")
            .WithMessage("File path must be specified*");
    }
}