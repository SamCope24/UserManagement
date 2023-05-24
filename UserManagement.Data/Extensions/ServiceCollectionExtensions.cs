using UserManagement.Data;

namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDataAccess(this IServiceCollection services, bool useInMemory)
        => useInMemory
            ? services.AddScoped<IDataContext, InMemoryDataContext>()
            : services.AddScoped<IDataContext, PostgresDataContext>();
}
