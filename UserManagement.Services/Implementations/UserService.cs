using System;
using System.Collections.Generic;
using System.Linq;
using UserManagement.Common.Logging;
using UserManagement.Data;
using UserManagement.Data.Entities;
using UserManagement.Services.Domain.Interfaces;
using UserManagement.Services.Extensions;

namespace UserManagement.Services.Domain.Implementations;

public class UserService : IUserService
{
    private readonly IDataContext _dataAccess;
    private readonly ILogger _logger;

    public UserService(IDataContext dataAccess, ILogger logger)
    {
        _dataAccess = dataAccess ?? throw new ArgumentNullException(nameof(dataAccess));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public IEnumerable<User> FilterByActive(bool isActive)
        => GetAll().Where(user => user.IsActive == isActive);
    public IEnumerable<User> GetAll() => _dataAccess.GetAll<User>();
    public void AddUser(User user)
    {
        _dataAccess.Create(user);
        _logger.Log($"User Added - {user.Print()}");
    }
    public void DeleteUser(User user)
    {
        _dataAccess.Delete(user);
        _logger.Log($"User Deleted - {user.Print()}");
    }
    public void EditUser(User user) => _dataAccess.Update(user);
    public User? GetUser(long userId) => _dataAccess.GetById<User>(userId);
}
