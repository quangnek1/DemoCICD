using DemoCICD.Application.Behaviors;
using DemoCICD.Application.Mapper;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace DemoCICD.Application.DependencyInjection.Extensions;
public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddConfigureMediaR(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(AssemblyReference.Assembly))
            .AddValidatorsFromAssembly(Contract.AssemblyReference.Assembly, includeInternalTypes: true)
            .AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehavior<,>))
            .AddTransient(typeof(IPipelineBehavior<,>), typeof(TransactionPipelineBehavior<,>))
            ;
        return services;
    }

    public static IServiceCollection AddConfigurationAutoMapper(this IServiceCollection services)
    => services.AddAutoMapper(typeof(ServiceProfile));
}

//
//Thứ tự chuẩn phổ biến

//Tao recommend:
//👉 Logging / Tracing
//👉 Validation
//👉 Performance
//👉 Transaction
//👉 Handler
