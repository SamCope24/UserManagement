using UserManagement.Models;
using UserManagement.Web.Models.Users;
using System;
using UserManagement.Common.Mappers;

namespace UserManagement.Web.Mappers;

public class UserEntityToViewModelMapper : IMapper<User, UserListItemViewModel>
{
    public UserListItemViewModel MapFrom(User input)
    {
        if (input is null)
        {
            throw new ArgumentNullException(nameof(input));
        }

        return new UserListItemViewModel
        {
            Id = input.Id,
            Forename = input.Forename,
            Surname = input.Surname,
            Email = input.Email,
            IsActive = input.IsActive
        };
    }
}