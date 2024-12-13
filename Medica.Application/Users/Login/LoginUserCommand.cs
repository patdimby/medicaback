using Medica.Application.Abstractions.Messaging;

namespace Medica.Application.Users.Login;

public sealed record LoginUserCommand(string Email, string Password) : ICommand<string>;
