using Medica.Application.Abstractions.Messaging;

namespace Medica.Application.Todos.GetById;

public sealed record GetTodoByIdQuery(Guid TodoItemId) : IQuery<TodoResponse>;
