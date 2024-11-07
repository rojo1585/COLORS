
namespace COLORS.Models;

public record ColorValue(double number, string color)
{
    public double Number { get; set; } = number;
    public string Color { get; set; } = color;
}
