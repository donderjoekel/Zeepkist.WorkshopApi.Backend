using TNRD.Zeepkist.WorkshopApi.Database;
using TNRD.Zeepkist.WorkshopApi.Database.Models;

namespace TNRD.Zeepkist.WorkshopApi.Backend.Endpoints.Requests.Post;

public class Endpoint : Endpoint<RequestModel>
{
    private readonly ZworpshopContext context;

    public Endpoint(ZworpshopContext context)
    {
        this.context = context;
    }

    public override void Configure()
    {
        AllowAnonymous();
        Post("requests");
#if !DEBUG
        Description(b => b.ExcludeFromDescription());
#endif
    }

    public override async Task HandleAsync(RequestModel req, CancellationToken ct)
    {
        Request model = new()
        {
            WorkshopId = decimal.Parse(req.WorkshopId),
            Hash = req.Hash,
            Uid = req.Uid,
            DateCreated = DateTime.UtcNow
        };

        await context.Requests.AddAsync(model, ct);
        int changes = await context.SaveChangesAsync(ct);
        if (changes == 1)
        {
            await SendAsync(default!, 201, ct);
        }
        else
        {
            ThrowError("Failed to save request", 500);
        }
    }
}
