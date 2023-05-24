using UserManagement.Models;

namespace UserManagement.Data.Testing.Entities;

public static class UserTestDoubles
{
    public static User Stub(string forename = "Luke", string surname = "Skywalker", bool isActive = true)
        => new()
            {
                Forename = forename,
                Surname = surname,
                Email = $"{forename}.{surname}@rebelalliance.org",
                IsActive = isActive,
                DateOfBirth = DateTime.UtcNow
        };

    public static IEnumerable<User> StubCollection(int numberOfItems = 5)
        => Enumerable.Range(0, numberOfItems).Select(_ => Stub());
}