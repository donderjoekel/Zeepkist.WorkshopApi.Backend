using Microsoft.EntityFrameworkCore;
using TNRD.Zeepkist.WorkshopApi.Db;
using TNRD.Zeepkist.WorkshopApi.RequestModels;
using TNRD.Zeepkist.WorkshopApi.ResponseModels;

namespace TNRD.Zeepkist.WorkshopApi.Endpoints.Files.GetAll;

public class Endpoint : Endpoint<LimitOffsetRequestModel, IEnumerable<FileResponseModel>>
{
    private readonly ZworpshopContext context;

    public Endpoint(ZworpshopContext context)
    {
        this.context = context;
    }

    public override void Configure()
    {
        Get("files");
        AllowAnonymous();
    }

    public override async Task HandleAsync(LimitOffsetRequestModel req, CancellationToken ct)
    {
        await SendOkAsync(await context.Files
                .OrderBy(x => x.Id)
                .Skip(req.Offset)
                .Take(req.Limit)
                .Select(x => x.ToResponseModel())
                .ToListAsync(cancellationToken: ct),
            ct);
    }
}
