using UserManagement.Common.Mappers;

namespace UserManagement.Common.Testing;

public static class MapperTestDoubles
{
    public static IMapper<TFrom, TTo> Dummy<TFrom, TTo>()
        => Mock.Of<IMapper<TFrom, TTo>>();

    public static IMapper<TFrom, TTo> StubFor<TFrom, TTo>(TTo mapTo)
    {
        var mapper = new Mock<IMapper<TFrom, TTo>>();
        mapper.Setup(x => x.MapFrom(It.IsAny<TFrom>())).Returns(mapTo);
        return mapper.Object;
    }
}