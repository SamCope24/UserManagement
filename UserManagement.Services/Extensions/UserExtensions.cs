using UserManagement.Data.Entities;

namespace UserManagement.Services.Extensions;

public static class UserExtensions
{
    public static string Print(this User user) =>
        $"Id: {user.Id} " +
        $"Name: {user.Forename} {user.Surname} " +
        $"Email: {user.Email}";
}