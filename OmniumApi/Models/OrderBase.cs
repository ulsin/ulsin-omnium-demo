using System.Text.Json.Serialization;

namespace OmniumApi.Models;

[JsonPolymorphic]
[JsonDerivedType(typeof(Order), "order")]
[JsonDerivedType(typeof(PosOrder), "posOrder")]
public abstract class OrderBase
{
    public string OrderId { get; set; } = string.Empty;
    public string CustomerId { get; set; } = string.Empty;
    public string CustomerName { get; set; } = string.Empty;

    public float Total => CalculateOrderTotal();

    public List<OrderLine> OrderLines { get; set; } = [];

    private float CalculateOrderTotal() => OrderLines.Sum(line => line.Quantity * line.Price);
}