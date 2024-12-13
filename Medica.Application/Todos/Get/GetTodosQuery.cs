using Medica.Application.Abstractions.Messaging;

namespace Medica.Application.Todos.Get;

public sealed record GetTodosQuery(Guid UserId): IQuery<List<TodoResponse>>;
