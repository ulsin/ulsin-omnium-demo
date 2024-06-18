namespace OmniumApi.Models;

public class GroupedOrderLine
{
    public string ProductId { get; set; } = string.Empty;
    public string ProductName { get; set; } = string.Empty;
    public int TotalQuantity { get; set; }
    public float TotalPrice { get; set; }
}