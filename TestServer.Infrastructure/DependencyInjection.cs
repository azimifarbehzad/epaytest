using System.Reflection;

using Microsoft.Extensions.DependencyInjection;
using TestServer.Application.Common.Interfaces;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddSingleton<ICustomerService, CustomerService>();

        return services;
    }
}