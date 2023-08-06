using Microsoft.EntityFrameworkCore;
using TNRD.Zeepkist.WorkshopApi.Db;
using TNRD.Zeepkist.WorkshopApi.Db.Models;
using TNRD.Zeepkist.WorkshopApi.ResponseModels;

namespace TNRD.Zeepkist.WorkshopApi.Endpoints.Levels.GetByWorkshopId;

public class Endpoint : Endpoint<RequestModel, IEnumerable<LevelResponseModel>>
{
    private readonly ZworpshopContext context;

    public Endpoint(ZworpshopContext context)
    {
        this.context = context;
    }

    public override void Configure()
    {
        Get("levels/workshop/{id}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(RequestModel req, CancellationToken ct)
    {
        ulong id = ulong.Parse(req.Id);
        List<LevelModel> result = await context.Levels.AsNoTracking()
            .Where(x => x.WorkshopId == id)
            .Include(x => x.AuthorNavigation)
            .Include(x => x.FileNavigation)
            .OrderBy(x => x.Id)
            .ToListAsync(ct);

        if (result.Count > 0)
        {
            await SendOkAsync(result.Select(x => x.ToResponseModel()), ct);
        }
        else
        {
            await SendNotFoundAsync(ct);
        }
    }
}
