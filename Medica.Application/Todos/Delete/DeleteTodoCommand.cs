using Medica.Application.Abstractions.Messaging;

namespace Medica.Application.Todos.Delete;

public sealed record DeleteTodoCommand(Guid TodoItemId) : ICommand;
