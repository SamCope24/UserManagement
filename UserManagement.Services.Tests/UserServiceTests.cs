using System.Linq;
using UserManagement.Data.Testing.Entities;
using UserManagement.Models;
using UserManagement.Services.Domain.Implementations;

namespace UserManagement.Data.Tests;

public class UserServiceTests
{
    [Fact]
    public void GetAll_WhenContextReturnsEntities_MustReturnSameEntities()
    {
        // Arrange: Initializes objects and sets the value of the data that is passed to the method under test.
        var service = CreateService();
        var users = SetupUsers();

        // Act: Invokes the method under test with the arranged parameters.
        var result = service.GetAll();

        // Assert: Verifies that the action of the method under test behaves as expected.
        result.Should().BeSameAs(users);
    }

    private IQueryable<User> SetupUsers()
    {
        var users = new[]
        {
            UserTestDoubles.Stub(isActive: true),
            UserTestDoubles.Stub(isActive: false)
        }.AsQueryable();

        _dataContext
            .Setup(s => s.GetAll<User>())
            .Returns(users);

        return users;
    }

    private readonly Mock<IDataContext> _dataContext = new();
    private UserService CreateService() => new(_dataContext.Object);

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void Result_AfterCallingFilterByActive_IsFilteredCollectionOfUsers(bool isActive)
    {
        var service = CreateService();
        var users = SetupUsers();

        var result = service.FilterByActive(isActive);

        result.Should().AllSatisfy(x => x.IsActive.Should().Be(isActive));
    }
}
