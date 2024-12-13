using System.ComponentModel.DataAnnotations.Schema;
using Medica.SharedKernel.Abstracts;
using Newtonsoft.Json;

namespace Medica.Core.Domains;

[Table("Todos")]
public class TodoItem : AuditEntity<Guid>
{
    [Column("due")]
    [JsonProperty(PropertyName = "due_date")]
    public DateTime? DueDate { get; set; }

    [NotMapped] public List<string> Labels { get; set; } = [];

    [Column("is_completed")]
    [JsonProperty(PropertyName = "is_completed")]
    public bool IsCompleted { get; set; }

    [Column("title")]
    [JsonProperty(PropertyName = "title")]
    public string Title { get; set; } = "";

    [Column("assignee")]
    [JsonProperty(PropertyName = "assignee")]
    public string Assignee { get; set; } = "";
}