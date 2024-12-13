using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Flunt.Notifications;
using Medica.SharedKernel.Interfaces;

namespace Medica.SharedKernel.Abstracts;

/// <summary>
///     The entity base.
/// </summary>
public abstract class EntityBase<TKey> : Notifiable<BaseNotification>, IEntityBase<TKey>
{
    /// <summary>
    ///     Gets or sets the notifiable.
    /// </summary>
    [NotMapped]
    public Notifiable<BaseNotification>? Notifiable { get; set; }

    /// <summary>
    ///     Gets or sets the id.
    /// </summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public virtual required TKey Id { get; set; }
    [NotMapped]
    private readonly List<IDomainEvent> _domainEvents = [];
    [NotMapped]
    public List<IDomainEvent> DomainEvents => [.. _domainEvents];

    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }

    public void Raise(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }
}