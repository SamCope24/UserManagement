using UserManagement.Common.Mappers;
using UserManagement.Data.Entities;

namespace UserManagement.Services.Comparing;

public class UserDataToDtoMapper : IMapper<User, UserDto>
{
    public UserDto MapFrom(User input)
        => new()
        {
            Forename = input.Forename,
            Surname = input.Surname,
            Email = input.Email,
            IsActive = input.IsActive,
            DateOfBirth = input.DateOfBirth
        };

    public User MapTo(UserDto input) => throw new System.NotImplementedException();
}
