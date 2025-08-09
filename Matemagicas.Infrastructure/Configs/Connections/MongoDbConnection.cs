using Matemagicas.Infrastructure.Configs.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Matemagicas.Infrastructure.Configs.Connections;

public static class MongoDbConnection
{
    public static IServiceCollection AddConnection(this IServiceCollection services, string connectionString, string databaseName)
    {
        services.AddDbContext<MatemagicasDbContext>(options =>
        {
            options.UseMongoDB(connectionString, databaseName);
        });
        
        return services;
    }
}