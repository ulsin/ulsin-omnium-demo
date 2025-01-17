﻿using AutoFixture;
using OmniumApi.Models;

namespace OmniumApi.DataLayer;

public class OrderRepository : IOrderRepository
{
    private readonly List<OrderBase> _orders = InitializeFakeOrders();

    public async Task<OrderBase?> GetOrder(string orderId)
    {
        var orders = await GetOrders();
        return orders.FirstOrDefault(order => order.OrderId == orderId);
    }

    public Task<IEnumerable<OrderBase>> GetOrders()
    {
        return Task.FromResult<IEnumerable<OrderBase>>(_orders);
    }

    public async Task<IEnumerable<OrderBase>> GetOrdersByCustomerId(string customerId)
    {
        var orders = await GetOrders();
        return orders.Where(order => order.CustomerId == customerId);
    }

    public async Task<IEnumerable<OrderBase>> GetOrdersByProductId(string productId)
    {
        var orders = await GetOrders();
        return orders.Where(order => order.OrderLines.Any(line => line.ProductId == productId));
    }

    public async Task<List<GroupedOrderLine>> GetTopSellingProducts()
    {
        var orders = await GetOrders();
        var orderLines = orders.SelectMany(order => order.OrderLines);

        var groupedOrderLines = orderLines
            .GroupBy(ol => new { ol.ProductId, ol.ProductName })
            .Select(g => new GroupedOrderLine
            {
                ProductId = g.Key.ProductId,
                ProductName = g.Key.ProductName,
                TotalQuantity = g.Sum(ol => ol.Quantity),
                TotalPrice = g.Sum(ol => ol.Price * ol.Quantity)
            })
            .OrderByDescending(g => g.TotalQuantity)
            .ToList()[.. 5];

        return groupedOrderLines;
    }

    private static List<OrderBase> InitializeFakeOrders()
    {
        var orders = new List<OrderBase>();

        var fixture = new Fixture();

        for (var i = 0; i < 20; i++)
        {
            OrderBase orderBase;

            if (i % 2 == 0)
                orderBase = fixture.Create<Order>();
            else
                orderBase = fixture.Create<PosOrder>();

            orderBase.OrderId = $"{i + 1}";
            orderBase.CustomerId = $"{i / 2 + 1}";

            foreach (var orderLine in orderBase.OrderLines)
            {
                var id = (Random.Shared.Next(1, 1000) % 10) + 1; // limiting productIds to be in the range 1 - 10
                orderLine.ProductId = $"{id}";
                orderLine.ProductName = $"name{id}";
            }

            orders.Add(orderBase);
        }

        return orders;
    }
}