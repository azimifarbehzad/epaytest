using System.Reflection;

using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using FluentValidation;
using MediatR;

public static class DependencyInjection
{
    public static IServiceCollection AddMyApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        services.AddMediatR(cfg => {
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
        });

        return services;
    }
}