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

builder.Services.AddEndpoints(Assembly.GetExecutingAssembly());

builder.Services.AddEndpointsApiExplorer();

// avoid error : Could not resolve reference: Could not resolve pointer:
builder.Services.AddSwaggerGen(c =>  c.CustomSchemaIds(s => s.FullName.Replace("+", ".")));

builder.Services
    .AddApplication()
    .AddInfrastructure(builder.Configuration);

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
/* Avoid requiring ProblemDetailsService when IExceptionHandler is used */
builder.Services.AddProblemDetails(options =>
{
    options.CustomizeProblemDetails = context =>   { };
});

builder.Services.AddEndpoints(Assembly.GetExecutingAssembly());

var app = builder.Build();

app.MapEndpoints();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();

    app.UseSwaggerUI(opt => { opt.SwaggerEndpoint("/swagger/v1/swagger.json", "Medica.Api"); });

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

await app.RunAsync();