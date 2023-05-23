using UserManagement.Models;

namespace UserManagement.Services.Tests.Doubles;

public static class UserTestDoubles
{
    public static User Stub(string forename = "Luke", string surname = "Skywalker", bool isActive = true)
        => new()
            {
                Forename = "Luke",
                Surname = "Skywalker",
                Email = $"{forename}.{surname}@rebelalliance.org",
                IsActive = isActive
        };
}