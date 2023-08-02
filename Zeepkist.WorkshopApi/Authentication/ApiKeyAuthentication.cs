using System.Security.Claims;
using System.Security.Principal;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Primitives;

namespace TNRD.Zeepkist.WorkshopApi.Authentication;

public class ApiKeyAuthentication : AuthenticationHandler<AuthenticationSchemeOptions>
{
    internal const string SCHEME = "ApiKey";
    internal const string HEADER = "x-api-key";

    private readonly string apiKey;

    public ApiKeyAuthentication(
        IOptionsMonitor<AuthenticationSchemeOptions> options,
        ILoggerFactory logger,
        UrlEncoder encoder,
        ISystemClock clock,
        IConfiguration config
    )
        : base(options, logger, encoder, clock)
    {
        apiKey = config["Authentication:ApiKey"] ?? throw new InvalidOperationException("No API key configured.");
    }

    protected override Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        Request.Headers.TryGetValue(HEADER, out StringValues extractedApiKey);

        if (!IsPublicEndpoint() && !extractedApiKey.Equals(apiKey))
            return Task.FromResult(AuthenticateResult.Fail("Invalid API credentials!"));

        ClaimsIdentity identity = new(
            claims: new[] { new Claim("ClientID", "Default") },
            authenticationType: Scheme.Name);
        GenericPrincipal principal = new(identity, roles: null);
        AuthenticationTicket ticket = new(principal, Scheme.Name);

        return Task.FromResult(AuthenticateResult.Success(ticket));
    }
    
    private bool IsPublicEndpoint()
    {
        return Context
            .GetEndpoint()?
            .Metadata.OfType<AllowAnonymousAttribute>()
            .Any() is null or true;
    }
}
