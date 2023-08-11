using Microsoft.EntityFrameworkCore;
using TNRD.Zeepkist.WorkshopApi.Db;
using TNRD.Zeepkist.WorkshopApi.Db.Models;
using TNRD.Zeepkist.WorkshopApi.ResponseModels;

namespace TNRD.Zeepkist.WorkshopApi.Endpoints.Levels.Put;

public class Endpoint : Endpoint<RequestModel, LevelResponseModel>
{
    private readonly ZworpshopContext context;

    public Endpoint(ZworpshopContext context)
    {
        this.context = context;
    }

    public override void Configure()
    {
        Put("levels/{id}");
    }

    public override async Task HandleAsync(RequestModel req, CancellationToken ct)
    {
        LevelModel? level = await context.Levels.FirstOrDefaultAsync(x => x.Id == req.Id, ct);
        if (level == null)
        {
            await SendNotFoundAsync(ct);
            return;
        }

        level.ReplacedBy = req.Replacement;
        await context.SaveChangesAsync(ct);
        await SendOkAsync(level.ToResponseModel(), ct);
    }
}
