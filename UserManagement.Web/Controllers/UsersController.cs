using System.Linq;
using UserManagement.Services.Domain.Interfaces;
using UserManagement.Web.Models.Users;

namespace UserManagement.WebMS.Controllers;

[Route("users")]
public class UsersController : Controller
{
    private readonly IUserService _userService;
    public UsersController(IUserService userService) => _userService = userService;

    [HttpGet]
    public ViewResult List()
    {
        var items = _userService.GetAll().Select(p => new UserListItemViewModel
        {
            Id = p.Id,
            Forename = p.Forename,
            Surname = p.Surname,
            Email = p.Email,
            IsActive = p.IsActive
        }).ToList();

        var model = new UserListViewModel
        {
            Items = items
        };

        return View(model);
    }

    [HttpGet("active")]
    public IActionResult ActiveUsers()
    {
        var activeUsers = _userService.FilterByActive(true)
            .Select(p => new UserListItemViewModel
            {
                Id = p.Id,
                Forename = p.Forename,
                Surname = p.Surname,
                Email = p.Email,
                IsActive = p.IsActive
            })
            .ToList();

        var model = new UserListViewModel
        {
            Items = activeUsers
        };

        return View("List", model);
    }

    [HttpGet("inactive")]
    public IActionResult InActiveUsers()
    {
        var activeUsers = _userService.FilterByActive(false)
            .Select(p => new UserListItemViewModel
            {
                Id = p.Id,
                Forename = p.Forename,
                Surname = p.Surname,
                Email = p.Email,
                IsActive = p.IsActive
            })
            .ToList();

        var model = new UserListViewModel
        {
            Items = activeUsers
        };

        return View("List", model);
    }
}
