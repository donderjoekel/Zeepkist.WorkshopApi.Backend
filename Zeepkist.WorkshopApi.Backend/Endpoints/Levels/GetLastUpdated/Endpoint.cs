using Microsoft.EntityFrameworkCore;
using TNRD.Zeepkist.WorkshopApi.Backend.Db;
using TNRD.Zeepkist.WorkshopApi.Backend.ResponseModels;

namespace TNRD.Zeepkist.WorkshopApi.Backend.Endpoints.Levels.GetLastUpdated;

public class Endpoint : EndpointWithoutRequest<IEnumerable<LevelResponseModel>>
{
    private readonly ZworpshopContext context;

    public Endpoint(ZworpshopContext context)
    {
        this.context = context;
    }

    public override void Configure()
    {
        Get("levels/last-updated");
        AllowAnonymous();
        Description(b => b.ExcludeFromDescription());
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        await SendOkAsync(await context.Levels.AsNoTracking()
                .OrderByDescending(x => x.UpdatedAt)
                .Take(1)
                .Select(x => x.ToResponseModel())
                .ToListAsync(ct),
            ct);
    }
}
