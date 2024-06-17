namespace OmniumApi.DataLayer;

public class GroupedOrderLine
{
    public string ProductId { get; set; }
    public string ProductName { get; set; }
    public int TotalQuantity { get; set; }
    public float TotalPrice { get; set; }
}