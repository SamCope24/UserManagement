using System.Collections.Generic;
using System.Linq;
using UserManagement.Common.Logging;
using UserManagement.Data;
using UserManagement.Data.Entities;
using UserManagement.Data.Testing.Entities;
using UserManagement.Services.Domain.Implementations;

namespace UserManagement.Services.Tests.Implementations;

public class UserServiceTests
{
    private readonly Mock<IDataContext> _dataContext = new();

    [Fact]
    public void GetAll_WhenCalled_InvokesRepositoryGetAllMethodOnce()
    {
        var service = CreateService();
        service.GetAll();
        _dataContext.Verify(x => x.GetAll<User>(), Times.Once);
    }

    private static UserService CreateServiceWith(IDataContext dataAccess, ILogger logger)
        => new(dataAccess, logger);

    private UserService CreateService() =>
        CreateServiceWith(_dataContext.Object, DummyLogger());

    private static ILogger DummyLogger() => Mock.Of<ILogger>();

    [Fact]
    public void GetByIsActive_WhenCalled_InvokesRepositoryGetAllMethodOnce()
    {
        var service = CreateService();
        service.GetByIsActive(It.IsAny<bool>());
        _dataContext.Verify(x => x.GetAll<User>(), Times.Once);
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void Result_AfterCallingGetByIsActive_IsFilteredListOfUsers(bool isActive)
    {
        _dataContext.Setup(x => x.GetAll<User>()).Returns(AnyUsers().AsQueryable());
        var service = CreateService();

        var result = service.GetByIsActive(isActive);

        result.Should().AllSatisfy(x => x.IsActive.Equals(isActive));
    }

    private static IEnumerable<User> AnyUsers() => new User[]
    {
        new User { Id = 1, IsActive = true },
        new User { Id = 2, IsActive = false },
        new User { Id = 3, IsActive = true }
    };

    [Fact]
    public void AddUser_WhenCalled_InvokesRepositoryCreateMethodOnce()
    {
        var userToAdd = AnyUser();
        var service = CreateService();

        service.AddUser(userToAdd);

        _dataContext.Verify(x => x.Create(userToAdd), Times.Once);
    }

    private static User AnyUser() => UserTestDoubles.Stub();

    [Fact]
    public void DeleteUser_WhenCalled_InvokesRepositoryDeleteMethodOnce()
    {
        var userToDelete = AnyUser();
        _dataContext.Setup(x => x.GetById<User>(userToDelete.Id)).Returns(userToDelete);
        var service = CreateService();

        service.DeleteUser(userToDelete.Id);

        _dataContext.Verify(x => x.Delete(userToDelete), Times.Once);
    }

    [Fact]
    public void EditUser_WhenCalled_InvokesRepositoryUpdateMethodOnce()
    {
        var userToUpdate = AnyUser();
        var service = CreateService();

        service.EditUser(userToUpdate);

        _dataContext.Verify(x => x.Update(userToUpdate), Times.Once);
    }

    [Fact]
    public void GetUser_WhenCalled_InvokesRepositoryGetByIdMethodOnce()
    {
        const long UserId = 1;
        _dataContext.Setup(x => x.GetById<User>(UserId)).Returns(UserTestDoubles.Stub());
        var service = CreateService();

        service.GetUser(UserId);

        _dataContext.Verify(x => x.GetById<User>(UserId), Times.Once);
    }
}
