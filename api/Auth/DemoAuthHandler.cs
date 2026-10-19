using System.Security.Claims;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;

namespace Addresses.Api.Auth;

/// <summary>
/// Stands in for real authentication: every request is signed in as customer 1,
/// unless the X-Customer-Id header names another customer.
/// </summary>
public class DemoAuthHandler(IOptionsMonitor<AuthenticationSchemeOptions> options, ILoggerFactory logger, UrlEncoder encoder)
    : AuthenticationHandler<AuthenticationSchemeOptions>(options, logger, encoder)
{
    public const string SchemeName = "Demo";

    protected override Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        var customerId = Request.Headers.TryGetValue("X-Customer-Id", out var value) ? value.ToString() : "1";
        var identity = new ClaimsIdentity([new Claim(ClaimTypes.NameIdentifier, customerId)], SchemeName);
        return Task.FromResult(AuthenticateResult.Success(new AuthenticationTicket(new ClaimsPrincipal(identity), SchemeName)));
    }
}

public static class ClaimsPrincipalExtensions
{
    public static int GetCustomerId(this ClaimsPrincipal user) =>
        int.Parse(user.FindFirstValue(ClaimTypes.NameIdentifier)!);
}
