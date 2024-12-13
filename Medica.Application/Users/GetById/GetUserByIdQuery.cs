using Medica.Application.Abstractions.Messaging;

namespace Medica.Application.Users.GetById;

public sealed record GetUserByIdQuery(Guid UserId) : IQuery<UserResponse>;
