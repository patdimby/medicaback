using MediatR;
using Medica.API.Extensions;
using Medica.API.Infrastructure;
using Medica.Application.Users;
using Medica.Application.Users.GetById;
using Medica.SharedKernel.Models;
using Web.Api.Endpoints.Users;

namespace Medica.API.Endpoints.Users;

internal sealed class GetById : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("users/{userId}", async (Guid userId, ISender sender, CancellationToken cancellationToken) =>
        {
            var query = new GetUserByIdQuery(userId);

            Result<UserResponse> result = await sender.Send(query, cancellationToken);

            return result.Match(Results.Ok, CustomResults.Problem);
        })
        .HasPermission(Permissions.UsersAccess)
        .WithTags(Tags.Users);
    }
}
