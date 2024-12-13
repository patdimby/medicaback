namespace Medica.API.Infrastructure;

public sealed class Request
{
    public Guid UserId { get; set; }
    public string Description { get; set; } = "";
    public DateTime? DueDate { get; set; }
    public List<string> Labels { get; set; } = [];
    public int Priority { get; set; }
}