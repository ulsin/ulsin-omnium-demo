namespace OmniumApi.Models;

public class OrderLine
{
    public string OrderLineId { get; set; } = string.Empty;
    public string ProductId { get; set; } = string.Empty;
    public string ProductName { get; set; } = string.Empty;
    public float Price { get; set; }
    public int Quantity { get; set; }
}