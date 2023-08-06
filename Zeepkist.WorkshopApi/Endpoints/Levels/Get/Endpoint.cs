using Microsoft.EntityFrameworkCore;
using TNRD.Zeepkist.WorkshopApi.Db;
using TNRD.Zeepkist.WorkshopApi.Db.Models;
using TNRD.Zeepkist.WorkshopApi.RequestModels;
using TNRD.Zeepkist.WorkshopApi.ResponseModels;

namespace TNRD.Zeepkist.WorkshopApi.Endpoints.Levels.Get;

public class Endpoint : Endpoint<IdRequestModel, LevelResponseModel>
{
    private readonly ZworpshopContext context;

    public Endpoint(ZworpshopContext context)
    {
        this.context = context;
    }

    public override void Configure()
    {
        Get("levels/{id}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(IdRequestModel req, CancellationToken ct)
    {
        LevelModel? result = await context.Levels.AsNoTracking()
            .Include(x => x.AuthorNavigation)
            .Include(x => x.FileNavigation)
            .FirstOrDefaultAsync(x => x.Id == req.Id, ct);

        if (result != null)
        {
            await SendOkAsync(result.ToResponseModel(), ct);
        }
        else
        {
            await SendNotFoundAsync(ct);
        }
    }
}
