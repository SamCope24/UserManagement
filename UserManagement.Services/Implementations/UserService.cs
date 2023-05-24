using System.Collections.Generic;
using System.Linq;
using UserManagement.Data;
using UserManagement.Data.Entities;
using UserManagement.Services.Domain.Interfaces;

namespace UserManagement.Services.Domain.Implementations;

public class UserService : IUserService
{
    private readonly IDataContext _dataAccess;
    public UserService(IDataContext dataAccess) => _dataAccess = dataAccess;
    public IEnumerable<User> FilterByActive(bool isActive)
        => GetAll().Where(user => user.IsActive == isActive);
    public IEnumerable<User> GetAll() => _dataAccess.GetAll<User>();
    public void AddUser(User user) => _dataAccess.Create(user);
    public void DeleteUser(User user) => _dataAccess.Delete(user);
    public void EditUser(User user) => _dataAccess.Update(user);
    public User? GetUser(long userId) => _dataAccess.GetById<User>(userId);
}
