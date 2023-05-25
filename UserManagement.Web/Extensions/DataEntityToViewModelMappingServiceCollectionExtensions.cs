using Microsoft.Extensions.DependencyInjection;
using UserManagement.Common.Mappers;
using UserManagement.Data.Entities;
using UserManagement.Web.Mappers;
using UserManagement.Web.Models.Users;

namespace UserManagement.Web.Extensions;

public static class DataEntityToViewModelMappingServiceCollectionExtensions
{
    public static IServiceCollection AddDataEntityToViewModelMappers(this IServiceCollection services)
        => services.AddSingleton<IMapper<User, UserListItemViewModel>, UserEntityToViewModelMapper>();
}