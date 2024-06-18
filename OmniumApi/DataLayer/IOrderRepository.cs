using OmniumApi.Models;

namespace OmniumApi.DataLayer;

public interface IOrderRepository
{
    Task<IEnumerable<OrderBase>> GetOrders();
    Task<OrderBase?> GetOrder(string orderId);
    Task<IEnumerable<OrderBase>> GetOrdersByCustomerId(string customerId);
    Task<IEnumerable<OrderBase>> GetOrdersByProductId(string productId);
    Task<List<GroupedOrderLine>> GetTopSellingProducts();
}