using Microsoft.Extensions.DependencyInjection;
using UserManagement.Common.Logging;

namespace UserManagement.Web.Extensions;

public static class LoggingServiceCollectionExtensions
{
    public static IServiceCollection AddLogger(this IServiceCollection services)
        => services.AddScoped<ILogger, ConsoleLogger>();
}