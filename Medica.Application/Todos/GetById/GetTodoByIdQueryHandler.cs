using Medica.Application.Abstractions.Authentication;
using Medica.Application.Abstractions.Data;
using Medica.Application.Abstractions.Messaging;
using Medica.Core.Errors;
using Medica.SharedKernel.Models;
using Microsoft.EntityFrameworkCore;

namespace Medica.Application.Todos.GetById;

internal sealed class GetTodoByIdQueryHandler(IApplicationDbContext context, IUserContext userContext) 
    : IQueryHandler<GetTodoByIdQuery, TodoResponse>
{
    public async Task<Result<TodoResponse>> Handle(GetTodoByIdQuery query, CancellationToken cancellationToken)
    {
        TodoResponse? todo = await context.TodoItems
            .Where(todoItem => todoItem.Id == query.TodoItemId && todoItem.Id == userContext.UserId)
            .Select(todoItem => new TodoResponse
            {
                Id = todoItem.Id,
                UserId = todoItem.Id,
                Description = todoItem.Description,
                DueDate = todoItem.DueDate,
                Labels = todoItem.Labels,
                IsCompleted = todoItem.IsCompleted,
                CreatedAt = todoItem.CreatedDate,
                CompletedAt = todoItem.CompletedAt
            })
            .SingleOrDefaultAsync(cancellationToken);

        return todo ?? Result.Failure<TodoResponse>(TodoItemErrors.NotFound(query.TodoItemId));
    }
}
