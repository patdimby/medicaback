using Medica.SharedKernel.Interfaces;

namespace Medica.Core.Events;

public sealed record UserRegisteredDomainEvent(Guid UserId) : IDomainEvent;