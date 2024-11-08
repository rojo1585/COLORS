
namespace COLORS.Models;

public record ContainerValue(string? Id, object Value, Type? Type = null)
{
    public Type? Type { get; set; } = Type;
    public string? ID { get; set; } = Id;
    public object Value { get; set; } = Value;
}
