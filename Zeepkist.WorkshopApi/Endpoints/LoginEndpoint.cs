using System.Reflection.Metadata;
using FastEndpoints.Security;

namespace Zeepkist.WorkshopApi.Endpoints;

public class LoginEndpoint : EndpointWithoutRequest
{
    public override void Configure()
    {
        Get("login");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        await CookieAuth.SignInAsync(u => { });
        await SendOkAsync(ct);
    }
}
