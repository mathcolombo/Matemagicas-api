using Microsoft.Extensions.DependencyInjection;

namespace Matemagicas.Ioc;

public static class DependencyInjection
{
    public static IServiceCollection AddAbstractions(this IServiceCollection services)
    {
        // services.Scan(scan => scan
        //     .FromAssemblies(typeof(Repository<>).Assembly)
        //     .AddClasses(classes => classes.AssignableTo(typeof(Repository<>)))
        //     .AsImplementedInterfaces()
        //     .WithScopedLifetime());
        // services.AddScoped<IUnitOfWork, UnitOfWork>();
        
        return services;
    }

    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        return services;
    }

    public static IServiceCollection AddDomainServices(this IServiceCollection services)
    {
        return services;
    }

    public static IServiceCollection AddInfrastructureRepositories(this IServiceCollection services)
    {
        return services;
    }
}