using Medica.Application.Abstractions.Messaging;

namespace Medica.Application.Todos.Complete;

public sealed record CompleteTodoCommand(Guid TodoItemId) : ICommand;
