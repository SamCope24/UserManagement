namespace UserManagement.Common.Mappers;

public interface IMapper<TMapFrom, TMapTo>
{
    TMapTo MapFrom(TMapFrom input);
    TMapFrom MapTo(TMapTo input);
}