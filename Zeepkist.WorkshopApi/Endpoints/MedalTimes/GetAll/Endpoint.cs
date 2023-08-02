using Microsoft.EntityFrameworkCore;

using Zeepkist.WorkshopApi.Db;
using Zeepkist.WorkshopApi.RequestModels;
using Zeepkist.WorkshopApi.ResponseModels;

namespace Zeepkist.WorkshopApi.Endpoints.MedalTimes.GetAll;

public class Endpoint : Endpoint<LimitOffsetRequestModel, IEnumerable<MedalsResponseModel>>
{
    private readonly ZworpshopContext context;

    public Endpoint(ZworpshopContext context)
    {
        this.context = context;
    }

    public override void Configure()
    {
        Get("medals");
        AllowAnonymous();
    }

    public override async Task HandleAsync(LimitOffsetRequestModel req, CancellationToken ct)
    {
        await SendOkAsync(await context.Medals
                .Skip(req.Offset)
                .Take(req.Limit)
                .Select(x => x.ToResponseModel())
                .ToListAsync(cancellationToken: ct),
            ct);
    }
}
