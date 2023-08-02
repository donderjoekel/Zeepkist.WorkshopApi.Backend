using Microsoft.EntityFrameworkCore;
using Zeepkist.WorkshopApi.Db;
using Zeepkist.WorkshopApi.RequestModels;
using Zeepkist.WorkshopApi.ResponseModels;

namespace Zeepkist.WorkshopApi.Endpoints.Files.GetAll;

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
