using Medica.SharedKernel.Interfaces;

namespace Medica.Core.Events;

public sealed record TodoItemCompletedDomainEvent(Guid TodoItemId) : IDomainEvent;
public sealed record TodoItemCreatedDomainEvent(Guid TodoItemId) : IDomainEvent;
public sealed record TodoItemDeletedDomainEvent(Guid TodoItemId) : IDomainEvent;
