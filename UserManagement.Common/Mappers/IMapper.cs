namespace UserManagement.Common.Mappers;

public interface IMapper<TMapFrom, TMapTo>
{
    TMapTo MapFrom(TMapFrom input);
}