using Medica.Application.Abstractions.Messaging;

namespace Medica.Application.Users.GetByEmail;

public sealed record GetUserByEmailQuery(string Email) : IQuery<UserResponse>;
