using Medica.Application.Abstractions.Messaging;

namespace Medica.Application.Users.Register;

public sealed record RegisterUserCommand(string Email, string FirstName, string LastName, string Password)
    : ICommand<Guid>;
