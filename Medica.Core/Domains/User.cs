using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Medica.SharedKernel.Abstracts;
using Newtonsoft.Json;

namespace Medica.Core.Domains;

[Table("Users")]
public class User: AuditEntity<Guid>
{
    public required string Email { get; set; }
    /// <summary>
    ///     Gets or sets the name.
    /// </summary>
    [Required(ErrorMessage = "Name is a required field.")]
    [MaxLength(30, ErrorMessage = "Maximum length for the Name is 30 characters.")]
    [Column("name")]
    [JsonProperty(PropertyName = "name")]
    public required string FirstName { get; set; }
    [JsonProperty(PropertyName = "last_name")]
    public string LastName { get; set; } = "";
    [Required(ErrorMessage = "Password is a required field.")]
    [JsonProperty(PropertyName = "password")]
    public required string PasswordHash { get; set; }
}