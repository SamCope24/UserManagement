using System;
using UserManagement.Services.Comparing;

namespace UserManagement.Services.Tests.Comparing;

public class UserDtoComparerTests
{
    [Fact]
    public void Compare_CalledWithNullOldUser_ThrowsArgumentNullException()
    {
        var comparer = CreateComparer();
        comparer.Invoking(x => x.Compare(oldUser: null!, AnyUserDto()))
            .Should()
            .Throw<ArgumentNullException>()
            .WithParameterName("oldUser");
    }

    private static UserDtoComparer CreateComparer() => new();

    private static UserDto AnyUserDto() => new();

    [Fact]
    public void Compare_CalledWithNullNewUser_ThrowsArgumentNullException()
    {
        var comparer = CreateComparer();
        comparer.Invoking(x => x.Compare(AnyUserDto(), newUser: null!))
            .Should()
            .Throw<ArgumentNullException>()
            .WithParameterName("newUser");
    }

    [Fact]
    public void Changes_AfterCallingCompareOnSameUsers_IsEmpty()
    {
        var comparer = CreateComparer();
        var userToCompare = AnyUserDto();

        var changes = comparer.Compare(userToCompare, userToCompare);

        changes.Should().BeEmpty();
    }

    [Fact]
    public void Changes_AfterCallingCompareOnDuplicateUsers_IsEmpty()
    {
        var firstUserToCompare = new UserDto() { Forename = "Sam"};
        var secondUserToCompare = new UserDto() { Forename = "Sam"};
        var comparer = CreateComparer();

        var changes = comparer.Compare(firstUserToCompare, secondUserToCompare);

        changes.Should().BeEmpty();
    }

    [Fact]
    public void Changes_AfterCallingCompareOnDifferentUsers_IsNotEmpty()
    {
        var firstUserToCompare = new UserDto() { Forename = "Sam"};
        var comparer = CreateComparer();

        var changes = comparer.Compare(firstUserToCompare, AnyUserDto());

        changes.Should().NotBeEmpty();
    }

    [Fact]
    public void Changes_AfterCallingCompareOnDifferentObject_HasAmountOfExpectedChanges()
    {
        var firstUserToCompare = new UserDto() { Forename = "Darth", Surname = "Vader"};
        var secondUserToCompare = new UserDto() { Forename = "Mace", Surname = "Windu"};
        var comparer = CreateComparer();

        var changes = comparer.Compare(firstUserToCompare, secondUserToCompare);

        changes.Should().HaveCount(2);
    }

    [Fact]
    public void Changes_AfterCallingCompareOnDifferentObject_HasKeysForChangedFields()
    {
        var firstUserToCompare = new UserDto() { Forename = "Darth", Surname = "Vader"};
        var secondUserToCompare = new UserDto() { Forename = "Baby", Surname = "Yoda"};
        var comparer = CreateComparer();

        var changes = comparer.Compare(firstUserToCompare, secondUserToCompare);

        changes.Should().ContainKeys("Forename", "Surname");
    }

    [Fact]
    public void Changes_AfterCallingCompareOnDifferentObject_DoesNotHaveKeysForUnChangedFields()
    {
        var firstUserToCompare = new UserDto() { Forename = "The", Surname = "Mandalorian", IsActive = true};
        var secondUserToCompare = new UserDto() { Forename = "The", Surname = "Mandalorian", IsActive = false};
        var comparer = CreateComparer();

        var changes = comparer.Compare(firstUserToCompare, secondUserToCompare);

        changes.Should().NotContainKeys("Forename", "Surname");
    }
}
