using System.Text.Json.Serialization;

namespace OmniumApi.Models;

public interface IOrder
{
    string OrderId { get; set; }
    string CustomerId { get; set; }
    string CustomerName { get; set; }
    float Total { get; set; }
    List<OrderLine> OrderLines { get; set; }
}

[JsonPolymorphic]
[JsonDerivedType(typeof(Order), "order")]
[JsonDerivedType(typeof(PosOrder), "posOrder")]
public abstract class OrderBase
{
    public string OrderId { get; set; }
    public string CustomerId { get; set; }
    public string CustomerName { get; set; }

    public float Total => CalculateOrderTotal();

    public List<OrderLine> OrderLines { get; set; }

    private float CalculateOrderTotal() => this.OrderLines.Sum(line => line.Quantity * line.Price);
}

[JsonDerivedType(typeof(Order), "order")]
public class Order : OrderBase
{
    // public string OrderId { get; set; }
    // public string CustomerId { get; set; }
    // public string CustomerName { get; set; }
    // public float Total { get; set; }
    // public List<OrderLine> OrderLines { get; set; }
}

[JsonDerivedType(typeof(PosOrder), "posOrder")]
public class PosOrder : OrderBase
{
    public string PosId { get; set; }
}

public class OrderLine
{
    public string OrderLineId { get; set; }
    public string ProductId { get; set; }
    public string ProductName { get; set; }
    public float Price { get; set; }
    public int Quantity { get; set; }
}