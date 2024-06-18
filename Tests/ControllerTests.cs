using System.Net;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using OmniumApi.Models;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Tests;

public class ControllerTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;

    public ControllerTests(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task GetOrderTest()
    {
        // Arrange
        var client = _factory.CreateClient();
        var orderIds = Enumerable.Range(1, 20);

        // Act
        var responses = await Task.WhenAll(
            orderIds.Select(async orderId => await client.GetAsync($"/Order/GetOrder?orderId={orderId}"))
        );

        var act = async () =>
        {
            foreach (var response in responses)
                JsonSerializer.Deserialize<OrderBase>(await response.Content.ReadAsStringAsync());
        };

        // Assert
        responses.Should().AllSatisfy(message => message.StatusCode.Should().Be(HttpStatusCode.OK));

        await act.Should().NotThrowAsync();
    }

    [Fact]
    public async Task GetOrdersTest()
    {
        // Arrange
        var client = _factory.CreateClient();

        // Act
        var response = await client.GetAsync("/Order/GetOrders");

        var orders = JsonSerializer.Deserialize<List<OrderBase>>(await response.Content.ReadAsStringAsync());

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        orders.Should().HaveCount(20);
    }

    [Fact]
    public async Task GetOrdersByCustomerIdTest()
    {
        // Arrange
        var client = _factory.CreateClient();

        const int customerId = 1;

        // Act
        var response = await client.GetAsync($"/Order/GetOrdersByCustomerId?customerId={customerId}");

        var orders = JsonSerializer.Deserialize<List<OrderBase>>(await response.Content.ReadAsStringAsync());

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        orders.Should().HaveCount(2);
    }

    [Fact]
    public async Task GetOrdersByProductIdTest()
    {
        // Arrange
        var client = _factory.CreateClient();

        const int productId = 1;

        // Act
        var response = await client.GetAsync($"/Order/GetOrdersByProductId?productId={productId}");

        var orders = JsonSerializer.Deserialize<List<OrderBase>>(await response.Content.ReadAsStringAsync());

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        orders.Should().HaveCountGreaterThan(0);
    }

    [Fact]
    public async Task GetTopSellingProductsTest()
    {
        // Arrange
        var client = _factory.CreateClient();

        // Act
        var response = await client.GetAsync("/Order/GetTopSellingProducts");

        var orders = JsonSerializer.Deserialize<List<GroupedOrderLine>>(await response.Content.ReadAsStringAsync());

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        orders.Should().HaveCountGreaterThan(0);
    }
}