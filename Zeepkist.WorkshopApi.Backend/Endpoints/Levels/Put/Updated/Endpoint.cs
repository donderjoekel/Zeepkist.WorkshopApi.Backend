using Microsoft.EntityFrameworkCore;
using TNRD.Zeepkist.WorkshopApi.Backend.Db;
using TNRD.Zeepkist.WorkshopApi.Backend.Db.Models;
using TNRD.Zeepkist.WorkshopApi.Backend.ResponseModels;

namespace TNRD.Zeepkist.WorkshopApi.Backend.Endpoints.Levels.Put.Updated;

public class Endpoint : Endpoint<RequestModel, LevelResponseModel>
{
    private readonly ZworpshopContext context;

    public Endpoint(ZworpshopContext context)
    {
        this.context = context;
    }

    public override void Configure()
    {
        Put("levels/{id}/updated");
        Description(b => b.ExcludeFromDescription());
    }

    public override async Task HandleAsync(RequestModel req, CancellationToken ct)
    {
        LevelModel? level = await context.Levels.FirstOrDefaultAsync(x => x.Id == req.Id, ct);
        if (level == null)
        {
            await SendNotFoundAsync(ct);
            return;
        }

        level.UpdatedAt = DateTimeOffset.FromUnixTimeSeconds(req.Ticks).UtcDateTime;
        await context.SaveChangesAsync(ct);
        await SendOkAsync(level.ToResponseModel(), ct);
    }
}
