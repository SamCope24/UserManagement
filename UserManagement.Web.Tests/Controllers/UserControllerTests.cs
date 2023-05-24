using System;
using UserManagement.Common.Mappers;
using UserManagement.Common.Testing;
using UserManagement.Data.Entities;
using UserManagement.Data.Testing.Entities;
using UserManagement.Services.Domain.Interfaces;
using UserManagement.Web.Models.Users;
using UserManagement.WebMS.Controllers;

namespace UserManagement.Web.Tests.Controllers;

public class UserControllerTests
{
    private readonly Mock<IUserService> _userService = new();

    public UserControllerTests()
    {
        SetupUsers();
    }

    private User[] SetupUsers(string forename = "Darth", string surname = "Vader")
    {
        var users = new[]
        {
            UserTestDoubles.Stub(forename, surname, isActive: true)
        };

        _userService
            .Setup(s => s.GetAll())
            .Returns(users);

        _userService
            .Setup(s => s.FilterByActive(It.IsAny<bool>()))
            .Returns(users);

        return users;
    }

    [Fact]
    public void Constructor_CalledWithNullUserService_ThrowsArgumentNullException()
    {
        FluentActions.Invoking(() => CreateControllerWith(userService: null!, DummyMapper()))
            .Should()
            .Throw<ArgumentNullException>()
            .WithParameterName("userService");
    }

    private static IMapper<User, UserListItemViewModel> DummyMapper() => MapperTestDoubles.Dummy<User, UserListItemViewModel>();

    [Fact]
    public void Constructor_CalledWithNullDataEntityToViewModelMapper_ThrowsArgumentNullException()
    {
        FluentActions.Invoking(() => CreateControllerWith(_userService.Object, dataEntityToViewModelMapper: null!))
            .Should()
            .Throw<ArgumentNullException>()
            .WithParameterName("dataEntityToViewModelMapper");
    }

    [Fact]
    public void List_WhenCalled_InvokesUserServiceGetAllOnce()
    {
        var controller = CreateController();
        controller.List();
        _userService.Verify(x => x.GetAll(), Times.Once);
    }

    [Fact]
    public void List_WhenServiceReturnsUsers_ModelMustContainUsers()
    {
        var controller = CreateController();
        var result = controller.List();
        result.Model
            .Should().BeOfType<UserListViewModel>()
            .Which.Items.Should().NotBeEmpty();
    }

    private UsersController CreateController() => CreateControllerWith(_userService.Object, StubMapperFor(AnyUserListItemViewModel()));

    private static UsersController CreateControllerWith(IUserService userService, IMapper<User, UserListItemViewModel> dataEntityToViewModelMapper) =>
        new(userService, dataEntityToViewModelMapper);

    private static IMapper<User, UserListItemViewModel> StubMapperFor(UserListItemViewModel viewModel) => MapperTestDoubles.StubForMapFrom<User, UserListItemViewModel>(viewModel);

    private static UserListItemViewModel AnyUserListItemViewModel(string forename = "Darth", string surname = "Vader") => new() {
        Forename = forename,
        Surname = surname
    };

    [Fact]
    public void FilterByActive_WhenServiceReturnsUsers_ModelMustContainUsers()
    {
        var controller = CreateController();
        var result = controller.FilterByActive(true);
        result.Model
            .Should().BeOfType<UserListViewModel>()
            .Which.Items.Should().NotBeEmpty();
    }

    [Fact]
    public void FilterByActive_WhenCalled_InvokesUserServiceFilterByActiveOnce()
    {
        var controller = CreateController();
        const bool IsActive = true;
        controller.FilterByActive(IsActive);
        _userService.Verify(x => x.FilterByActive(IsActive), Times.Once);
    }

    [Fact]
    public void Delete_WhenCalled_InvokesUserServiceGetUserOnce()
    {
        var controller = CreateController();
        const int UserId = 5;
        controller.Delete(UserId);
        _userService.Verify(x => x.GetUser(UserId), Times.Once);
    }

    [Fact]
    public void Delete_WhenCalled_InvokesUserServiceDeleteUserOnce()
    {
        var controller = CreateController();
        var userToBeDeleted = UserTestDoubles.Stub();
        _userService.Setup(x => x.GetUser(It.IsAny<long>())).Returns(userToBeDeleted);

        controller.Delete(userToBeDeleted.Id);

        _userService.Verify(x => x.DeleteUser(userToBeDeleted), Times.Once);
    }
}