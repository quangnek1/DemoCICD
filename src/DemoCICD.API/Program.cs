using DemoCICD.API.DependencyInjection.Extensions;
using DemoCICD.API.Middleware;
using DemoCICD.Application.DependencyInjection.Extensions;
using DemoCICD.Contract.Logging;
using DemoCICD.Infrastructure.Dapper.DependencyInjection.Extensions;
using DemoCICD.Persistence.DependencyInjection.Extensions;
using DemoCICD.Persistence.DependencyInjection.Options;
using DemoCICD.Presentation.DependencyInjection.Extensions;
using MicroElements.Swashbuckle.FluentValidation.AspNetCore;
using Serilog;
using DemoCICD.Presentation.APIs.Products;
using Carter;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog(Serilogger.Configure);
Log.Information(messageTemplate: $"Starting {builder.Environment.EnvironmentName}...");

try
{
    builder.Services.AddSwaggerGen();
    builder.Services.AddTransient<ExceptionHandlingMiddleware>();

    //Add Configuration
    builder.Services.AddConfigureMediaR();
    builder.Services.ConfigureSqlServerRetryOptions(builder.Configuration.GetSection(nameof(SqlServerRetryOptions)));
    builder.Services.AddSqlConfiguration();
    builder.Services.AddRepositoryBaseConfiguration();
    builder.Services.AddConfigurationAutoMapper();
    builder.Services.AddInfrastructureDapper();

    // Api
    builder.Services.AddControllers()
        .AddApplicationPart(DemoCICD.Presentation.AssemblyReference.Assembly);

    builder.Services
        .AddSwaggerGenNewtonsoftSupport()
        .AddFluentValidationRulesToSwagger()
        .AddEndpointsApiExplorer()
        .AddSwagger();

    builder.Services.AddApiVersioningConfiguration();

    builder.Services.AddCarter();

    var app = builder.Build();

    app.UseMiddleware<ExceptionHandlingMiddleware>();

    // Add API Endpoint
    app.NewVersionedApi("products-minimal-show-on-swagger").MapProductApiV1().MapProductApiV2();

    // Add API Endpoint with Carter
    app.MapCarter();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment() || builder.Environment.IsStaging())
    {
        app.ConfigureSwagger();
    }

    //app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
catch (Exception ex)
{
    string type = ex.GetType().Name;
    if (type.Equals("StopTheHostException", StringComparison.Ordinal))
        throw;

    Log.Fatal(ex, messageTemplate: "Unhandled exception");
}
finally
{
    Log.Information(messageTemplate: $"Shut down {builder.Environment.EnvironmentName} complete");
    Log.CloseAndFlush();
}

