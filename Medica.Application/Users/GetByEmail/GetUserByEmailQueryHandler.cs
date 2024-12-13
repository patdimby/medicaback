using Medica.Application.Abstractions.Authentication;
using Medica.Application.Abstractions.Data;
using Medica.Application.Abstractions.Messaging;
using Medica.Core.Errors;
using Medica.SharedKernel.Models;
using Microsoft.EntityFrameworkCore;

namespace Medica.Application.Users.GetByEmail;

internal sealed class GetUserByEmailQueryHandler(IApplicationDbContext context, IUserContext userContext)
    : IQueryHandler<GetUserByEmailQuery, UserResponse>
{
    public async Task<Result<UserResponse>> Handle(GetUserByEmailQuery query, CancellationToken cancellationToken)
    {
        var user = await context.Users
            .Where(u => u.Email == query.Email)
            .Select(u => new UserResponse
            {
                Id = u.Id,
                FirstName = u.FirstName,
                LastName = u.LastName,
                Email = u.Email
            })
            .SingleOrDefaultAsync(cancellationToken);

        if (user is null)
        {
            return Result.Failure<UserResponse>(UserErrors.NotFoundByEmail);
        }

        return user.Id != userContext.UserId ? Result.Failure<UserResponse>(UserErrors.Unauthorized()) : user;
    }
}
