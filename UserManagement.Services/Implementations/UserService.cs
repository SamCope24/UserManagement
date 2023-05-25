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

    public IEnumerable<User> GetByIsActive(bool isActive)
        => GetAll().Where(user => user.IsActive == isActive);
    public IEnumerable<User> GetAll() => _dataAccess.GetAll<User>();
    public void AddUser(User user)
    {
        _dataAccess.Create(user);
        _logger.Log($"User Added - {user.Print()}");
    }
    public void DeleteUser(long userId)
    {
        try
        {
            var user = GetUserData(userId);
            _dataAccess.Delete(user);
            _logger.Log($"User Deleted - {user.Print()}");
        }
        catch(Exception ex)
        {
            _logger.LogError(ex);
            throw;
        }
    }
    public void EditUser(User user)
    {
        try
        {
            _dataAccess.Update(user);
            _logger.Log($"User Edited - {user.Print()}");
        }
        catch(Exception ex)
        {
            _logger.LogError(ex);
            throw;
        }
    }

    public User? GetUser(long userId)
    {
        try
        {
            var user = GetUserData(userId);
            _logger.Log($"User Viewed - {user.Print()}");
            return user;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex);
            return default;
        }
    }

    private User GetUserData(long userId)
        => _dataAccess.GetById<User>(userId) ?? throw new Exception($"Could not find record for User; userId={userId}");
}
