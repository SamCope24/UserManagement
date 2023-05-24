using System;
using UserManagement.Data.Testing.Entities;
using UserManagement.Models;
using UserManagement.Web.Mappers;

namespace UserManagement.Web.Tests.Mappers;

public class UserEntityToViewModelMapperTests
{
    [Fact]
    public void MapFrom_WhenCalledWithNullInput_ThrowsArgumentNullException()
    {
        var mapper = CreateMapper();
        mapper.Invoking(x => x.MapFrom(null!))
            .Should()
            .Throw<ArgumentNullException>()
            .WithParameterName("input");
    }

    private static UserEntityToViewModelMapper CreateMapper() => new();

    [Fact]
    public void Id_AfterCallingMapFrom_HasValueAssignedFromDataEntity()
    {
        var mapper = CreateMapper();
        var input = AnyUser();

        var result = mapper.MapFrom(input);

        result.Id.Should().Be(input.Id);
    }

    private static User AnyUser() => UserTestDoubles.Stub();

    [Fact]
    public void Forename_AfterCallingMapFrom_HasValueAssignedFromDataEntityIdProperty()
    {
        var mapper = new UserEntityToViewModelMapper();
        var input = AnyUser();

        var result = mapper.MapFrom(input);

        result.Forename.Should().Be(input.Forename);
    }

    [Fact]
    public void Surname_AfterCallingMapFrom_HasValueAssignedFromDataEntitySurnameProperty()
    {
        var mapper = new UserEntityToViewModelMapper();
        var input = AnyUser();

        var result = mapper.MapFrom(input);

        result.Surname.Should().Be(input.Surname);
    }

    [Fact]
    public void Email_AfterCallingMapFrom_HasValueAssignedFromDataEntityEmailProperty()
    {
        var mapper = new UserEntityToViewModelMapper();
        var input = AnyUser();

        var result = mapper.MapFrom(input);

        result.Email.Should().Be(input.Email);
    }

    [Fact]
    public void IsActive_AfterCallingMapFrom_HasValueAssignedFromDataEntityIsActiveProperty()
    {
        var mapper = new UserEntityToViewModelMapper();
        var input = AnyUser();

        var result = mapper.MapFrom(input);

        result.IsActive.Should().Be(input.IsActive);
    }

    [Fact]
    public void DateOfBirth_AfterCallingMapFrom_HasValueAssignedFromDataEntityDateOfBirthProperty()
    {
        var mapper = new UserEntityToViewModelMapper();
        var input = AnyUser();

        var result = mapper.MapFrom(input);

        result.DateOfBirth.Should().Be(input.DateOfBirth);
    }
}