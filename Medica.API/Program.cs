using System.Reflection;
using HealthChecks.UI.Client;
using Medica.API.Extensions;
using Medica.API.Infrastructure;
using Medica.Application;
using Medica.Infrastructure;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, loggerConfig) => loggerConfig.ReadFrom.Configuration(context.Configuration));

builder.Services.AddControllers();

builder.Services.AddSwaggerGen();

builder.Services
    .AddApplication()
    .AddInfrastructure(builder.Configuration);
//.AddPresentation();

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
/* Avoid requiring ProblemDetailsService when IExceptionHandler is used */
builder.Services.AddProblemDetails(options =>
{
    options.CustomizeProblemDetails = context =>
    {
       //
	};
});

builder.Services.AddEndpoints(Assembly.GetExecutingAssembly());

var app = builder.Build();

app.MapEndpoints();

if (app.Environment.IsDevelopment())
{
    app.UseSwaggerWithUi();

    app.ApplyMigrations();
}

app.MapHealthChecks("health", new HealthCheckOptions
{
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});

app.UseRequestContextLogging();

app.UseSerilogRequestLogging();

app.UseExceptionHandler();

app.UseAuthentication();

app.UseAuthorization();

// REMARK: If you want to use Controllers, you'll need this.
app.MapControllers();

app.Run();