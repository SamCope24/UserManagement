using System;
using System.Linq;
using UserManagement.Common.Mappers;
using UserManagement.Data.Entities;
using UserManagement.Services.Domain.Interfaces;
using UserManagement.Web.Models.Users;

namespace UserManagement.WebMS.Controllers;

[Route("users")]
public class UsersController : Controller
{
    private readonly IUserService _userService;
    private readonly IMapper<User, UserListItemViewModel> _dataEntityToViewModelMapper;

    public UsersController(IUserService userService, IMapper<User, UserListItemViewModel> dataEntityToViewModelMapper)
    {
        _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        _dataEntityToViewModelMapper = dataEntityToViewModelMapper ?? throw new ArgumentNullException(nameof(dataEntityToViewModelMapper));
    }

    [HttpGet]
    public ViewResult List()
    {
        var userItems = GetUsers();
        return GetUserListViewResult(userItems);
    }

    private ViewResult GetUserListViewResult(List<UserListItemViewModel> items) => View("List", new UserListViewModel()
    {
        Items = items
    });

    private List<UserListItemViewModel> GetUsers() =>
        _userService.GetAll().Select(p => _dataEntityToViewModelMapper.MapFrom(p)).ToList();

    [HttpGet("filter-by-active")]
    public ViewResult ListByActive(bool isActive)
    {
        var activeUserItems = GetFilteredUsers(isActive);
        return GetUserListViewResult(activeUserItems);
    }

    private List<UserListItemViewModel> GetFilteredUsers(bool isActive) =>
        _userService.GetByIsActive(isActive).Select(_dataEntityToViewModelMapper.MapFrom).ToList();

    [HttpGet("delete/{id}")]
    public IActionResult Delete(long id)
    {
        try
        {
            _userService.DeleteUser(id);
            return RedirectToAction("List");
        }
        catch
        {
            TempData["ErrorMessage"] = "An error occurred while attempting to delete the user.";
            return RedirectToAction("List");
        }
    }

    [HttpGet("add")]
    public ViewResult Add()
    {
        return View();
    }

    [HttpPost("add")]
    public IActionResult Add(UserListItemViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        _userService.AddUser(_dataEntityToViewModelMapper.MapTo(model));
        return RedirectToAction("List");
    }

    [HttpGet("details/{id}")]
    public IActionResult Details(long id)
    {
        var user = _userService.GetUser(id);

        if (user is null)
        {
            return NotFound();
        }

        var viewModel = _dataEntityToViewModelMapper.MapFrom(user);

        return View(viewModel);
    }
}
