using System.Collections.Generic;
using UserManagement.Data.Entities;

namespace UserManagement.Services.Domain.Interfaces;

public interface IUserService
{
    /// <summary>
    /// Return users by active state
    /// </summary>
    /// <param name="isActive"></param>
    /// <returns></returns>
    IEnumerable<User> GetByIsActive(bool isActive);
    IEnumerable<User> GetAll();
    void AddUser(User user);
    void DeleteUser(long userId);
    void EditUser(User user);
    User? GetUser(long userId);
}
