using System.ComponentModel.DataAnnotations.Schema;
using Medica.SharedKernel.Attributes;
using Medica.SharedKernel.Interfaces;
using Medica.SharedKernel.Models;

namespace Medica.SharedKernel.Abstracts;

/// <summary>
///     The audit entity.
/// </summary>
public abstract class AuditEntity<TKey> : DeleteEntity<TKey>, IAuditEntity<TKey>
{
    /// <summary>
    ///     Gets or sets the created date.
    /// </summary>
    [Column("created")]
    //[JsonProperty(PropertyName = "created")]
    public DateTime CreatedDate { get; set; }

    /// <summary>
    ///     Gets or sets the created by.
    /// </summary>
    [Column("created_by")]
    //[JsonProperty(PropertyName = "created_by")]
    public string? CreatedBy { get; set; }

    /// <summary>
    ///     Gets or sets the updated date.
    /// </summary>
    [UpdateGreaterThanCreate("CreatedDate")]
    [Column("updated")]
    //[JsonProperty(PropertyName = "updated")]
    public DateTime? UpdatedDate { get; set; }

    /// <summary>
    ///     Gets or sets the updated by.
    /// </summary>
    [Column("updated_by")]
    //[JsonProperty(PropertyName = "updated_by")]
    public string? UpdatedBy { get; set; }
    //[JsonProperty(PropertyName = "completed_at")]
    [Column("completed_at")] public DateTime? CompletedAt { get; set; }
    //[JsonProperty(PropertyName = "description")]
    [Column("description")] public string Description { get; set; } = "";
    //[JsonProperty(PropertyName = "state")]
    [Column("state")] public State State { get; set; }
    //[JsonProperty(PropertyName = "priority")]
    [Column("priority")] public Priority Priority { get; set; }
}