using Microsoft.EntityFrameworkCore;
using TNRD.Zeepkist.WorkshopApi.Database;
using TNRD.Zeepkist.WorkshopApi.Backend.ResponseModels;
using TNRD.Zeepkist.WorkshopApi.Database;
using TNRD.Zeepkist.WorkshopApi.Database.Models;

namespace TNRD.Zeepkist.WorkshopApi.Backend.Endpoints.Levels.Delete;

public class Endpoint : Endpoint<RequestModel, LevelResponseModel>
{
    private readonly ZworpshopContext context;

    public Endpoint(ZworpshopContext context)
    {
        this.context = context;
    }

    public override void Configure()
    {
        Delete("levels/{id}");
        Description(b => b.ExcludeFromDescription());
    }

    public override async Task HandleAsync(RequestModel req, CancellationToken ct)
    {
        Level? level = await context.Levels.FirstOrDefaultAsync(x => x.Id == req.Id, ct);
        if (level == null)
        {
            await SendNotFoundAsync(ct);
            return;
        }

        if (level.Deleted)
        {
            await SendOkAsync(level.ToResponseModel(), ct);
            return;
        }

        level.Deleted = true;
        await context.SaveChangesAsync(ct);
        await SendOkAsync(level.ToResponseModel(), ct);
    }
}
