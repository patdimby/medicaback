using MediatR;
using Medica.API.Extensions;
using Medica.API.Infrastructure;
using Medica.Application.Todos;
using Medica.Application.Todos.Get;
using Medica.SharedKernel.Models;

namespace Medica.API.Endpoints.Todos;

internal sealed class Get : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("todos", async (Guid userId, ISender sender, CancellationToken cancellationToken) =>
        {
            var command = new GetTodosQuery(userId);

            Result<List<TodoResponse>> result = await sender.Send(command, cancellationToken);

            return result.Match(Results.Ok, CustomResults.Problem);
        })
        .WithTags(Tags.Todos)
        .RequireAuthorization();
    }
}
