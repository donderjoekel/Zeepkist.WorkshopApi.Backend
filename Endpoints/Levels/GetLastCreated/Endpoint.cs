using Microsoft.EntityFrameworkCore;
using TNRD.Zeepkist.WorkshopApi.Database;
using TNRD.Zeepkist.WorkshopApi.Backend.ResponseModels;
using TNRD.Zeepkist.WorkshopApi.Database;

namespace TNRD.Zeepkist.WorkshopApi.Backend.Endpoints.Levels.GetLastCreated;

public class Endpoint : EndpointWithoutRequest<IEnumerable<LevelResponseModel>>
{
    private readonly ZworpshopContext context;

    public Endpoint(ZworpshopContext context)
    {
        this.context = context;
    }

    public override void Configure()
    {
        Get("levels/last-created");
        AllowAnonymous();
        Description(b => b.ExcludeFromDescription());
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        await SendOkAsync(await context.Levels.AsNoTracking()
                .OrderByDescending(x => x.CreatedAt)
                .Take(1)
                .Select(x => x.ToResponseModel())
                .ToListAsync(ct),
            ct);
    }
}
