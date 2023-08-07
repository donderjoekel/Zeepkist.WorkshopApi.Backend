using Microsoft.EntityFrameworkCore;
using TNRD.Zeepkist.WorkshopApi.Db;
using TNRD.Zeepkist.WorkshopApi.RequestModels;
using TNRD.Zeepkist.WorkshopApi.ResponseModels;

namespace TNRD.Zeepkist.WorkshopApi.Endpoints.Levels.GetAll;

public class Endpoint : Endpoint<LimitOffsetRequestModel, IEnumerable<LevelResponseModel>>
{
    private readonly ZworpshopContext context;

    public Endpoint(ZworpshopContext context)
    {
        this.context = context;
    }

    public override void Configure()
    {
        Get("levels");
        AllowAnonymous();
    }

    public override async Task HandleAsync(LimitOffsetRequestModel req, CancellationToken ct)
    {
        await SendOkAsync(await context.Levels
                .AsNoTracking()
                .OrderBy(x => x.Id)
                .Skip(req.Offset)
                .Take(req.Limit)
                .Select(x => x.ToResponseModel())
                .ToListAsync(cancellationToken: ct),
            ct);
    }
}
