using System.Net;
using System.Net.Http.Json;
using Addresses.Api.Controllers;
using Microsoft.AspNetCore.Mvc.Testing;

namespace Addresses.Tests;

public class AddressesApiTests
{
    // Each test gets its own in-memory database with the sample data.
    private static HttpClient CreateClient() =>
        new WebApplicationFactory<Program>()
            .WithWebHostBuilder(b => b.UseSetting("DatabaseName", Guid.NewGuid().ToString()))
            .CreateClient();

    [Fact]
    public async Task GetAddresses_ReturnsTheCustomersAddresses()
    {
        var client = CreateClient();

        var addresses = await client.GetFromJsonAsync<List<AddressDto>>("/api/addresses");

        Assert.NotNull(addresses);
        Assert.Equal(3, addresses.Count);
    }

    [Fact]
    public async Task SetDefault_MarksTheAddressAsDefault()
    {
        var client = CreateClient();

        var response = await client.PutAsync("/api/addresses/2/default", null);
        var addresses = await client.GetFromJsonAsync<List<AddressDto>>("/api/addresses");

        Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        Assert.True(addresses!.Single(a => a.Id == 2).IsDefault);
    }
}
