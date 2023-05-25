using System.Diagnostics.CodeAnalysis;
using UserManagement.Common.Mappers;

namespace UserManagement.Common.Testing;

[ExcludeFromCodeCoverage]
public static class MapperTestDoubles
{
    public static IMapper<TFrom, TTo> Dummy<TFrom, TTo>()
        => Mock.Of<IMapper<TFrom, TTo>>();

    public static IMapper<TFrom, TTo> StubForMapFrom<TFrom, TTo>(TTo mapTo)
    {
        var mapper = new Mock<IMapper<TFrom, TTo>>();
        mapper.Setup(x => x.MapFrom(It.IsAny<TFrom>())).Returns(mapTo);
        return mapper.Object;
    }

    public static IMapper<TFrom, TTo> StubForMapTo<TFrom, TTo>(TFrom mapFrom)
    {
        var mapper = new Mock<IMapper<TFrom, TTo>>();
        mapper.Setup(x => x.MapTo(It.IsAny<TTo>())).Returns(mapFrom);
        return mapper.Object;
    }
}