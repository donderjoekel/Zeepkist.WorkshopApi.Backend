using Microsoft.EntityFrameworkCore;
using TNRD.Zeepkist.WorkshopApi.Db;
using TNRD.Zeepkist.WorkshopApi.Db.Models;
using TNRD.Zeepkist.WorkshopApi.ResponseModels;

namespace TNRD.Zeepkist.WorkshopApi.Endpoints.Levels.Exists;

public class Endpoint : Endpoint<RequestModel, LevelResponseModel>
{
    private readonly ZworpshopContext context;

    public Endpoint(ZworpshopContext context)
    {
        this.context = context;
    }

    public override void Configure()
    {
        Post("levels/exists");
        Description(b => b.ExcludeFromDescription());
    }

    public override async Task HandleAsync(RequestModel req, CancellationToken ct)
    {
        const float tolerance = 0.0001f;

        ulong workshopId = ulong.Parse(req.WorkshopId);
        ulong authorId = ulong.Parse(req.AuthorId);

        LevelModel? model = await context.Levels.AsNoTracking().FirstOrDefaultAsync(x =>
                x.Name == req.Name &&
                x.File == req.File &&
                x.Valid == req.Valid &&
                Math.Abs(x.Validation - req.Validation) < tolerance &&
                Math.Abs(x.Gold - req.Gold) < tolerance &&
                Math.Abs(x.Silver - req.Silver) < tolerance &&
                Math.Abs(x.Bronze - req.Bronze) < tolerance &&
                x.WorkshopId == workshopId &&
                x.AuthorId == authorId,
            ct);

        if (model != null)
        {
            await SendOkAsync(model.ToResponseModel(), ct);
        }
        else
        {
            await SendNotFoundAsync(ct);
        }
    }
}
