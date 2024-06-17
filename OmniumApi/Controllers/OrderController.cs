using Microsoft.AspNetCore.Mvc;
using OmniumApi.DataLayer;
using OmniumApi.Models;

namespace OmniumApi.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class OrderController : ControllerBase
{
    private readonly ILogger<OrderController> _logger;
    private readonly IOrderRepository _orderRepository;

    public OrderController(ILogger<OrderController> logger, IOrderRepository orderRepository)
    {
        _logger = logger;
        _orderRepository = orderRepository;
    }

    [HttpGet(Name = "GetOrder")]
    public async Task<ActionResult<OrderBase>> GetOrder(string orderId)
    {
        return Ok(await _orderRepository.GetOrder(orderId));
    }

    [HttpGet(Name = "GetOrders")]
    public async Task<ActionResult<IEnumerable<OrderBase>>> GetOrders()
    {
        return Ok(await _orderRepository.GetOrders());
    }

    [HttpGet(Name = "GetOrdersByCustomerId")]
    public async Task<ActionResult<IEnumerable<OrderBase>>> GetOrdersByCustomerId(string customerId)
    {
        return Ok(await _orderRepository.GetOrdersByCustomerId(customerId));
    }

    [HttpGet(Name = "GetOrdersByProductId")]
    public async Task<ActionResult<IEnumerable<OrderBase>>> GetOrdersByProductId(string productId)
    {
        return Ok(await _orderRepository.GetOrdersByProductId(productId));
    }

    [HttpGet(Name = "GetTopSellingProducts")]
    public async Task<ActionResult<IEnumerable<OrderBase>>> GetTopSellingProducts()
    {
        return Ok(await _orderRepository.GetTopSellingProducts());
    }
}