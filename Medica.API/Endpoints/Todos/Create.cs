using MediatR;
using Medica.API.Extensions;
using Medica.API.Infrastructure;
using Medica.Application.Todos.Create;
using Medica.SharedKernel.Models;


namespace Medica.API.Endpoints.Todos;

internal sealed class Create : IEndpoint
{
    

    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("todos", async (Request request, ISender sender, CancellationToken cancellationToken) =>
        {
            var command = new CreateTodoCommand
            {
                UserId = request.UserId,
                Description = request.Description,
                DueDate = request.DueDate,
                Labels = request.Labels,
                Priority = (Priority)request.Priority
            };

            Result<Guid> result = await sender.Send(command, cancellationToken);

            return result.Match(Results.Ok, CustomResults.Problem);
        })
        .WithTags(Tags.Todos)
        .RequireAuthorization();
    }
}
