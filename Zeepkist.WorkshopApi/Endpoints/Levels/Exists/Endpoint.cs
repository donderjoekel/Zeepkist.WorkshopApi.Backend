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
    }

    public override async Task HandleAsync(RequestModel req, CancellationToken ct)
    {
        ulong workshopId = ulong.Parse(req.WorkshopId);

        LevelModel? model = await context.Levels.FirstOrDefaultAsync(x =>
                x.Name == req.Name && 
                x.Author == req.Author && 
                x.File == req.File && 
                x.Medals == req.Medals &&
                x.WorkshopId == workshopId,
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
