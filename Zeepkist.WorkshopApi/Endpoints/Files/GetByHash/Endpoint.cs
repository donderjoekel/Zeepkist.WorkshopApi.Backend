using Microsoft.EntityFrameworkCore;
using TNRD.Zeepkist.WorkshopApi.Db;
using TNRD.Zeepkist.WorkshopApi.Db.Models;
using TNRD.Zeepkist.WorkshopApi.ResponseModels;

namespace TNRD.Zeepkist.WorkshopApi.Endpoints.Files.GetByHash;

public class Endpoint : Endpoint<RequestModel, FileResponseModel>
{
    private readonly ZworpshopContext context;

    public Endpoint(ZworpshopContext context)
    {
        this.context = context;
    }

    public override void Configure()
    {
        Get("files/hash/{hash}");
        AllowAnonymous();
    }
    
    public override async Task HandleAsync(RequestModel req, CancellationToken ct)
    {
        FileModel? result = await context.Files.AsNoTracking().FirstOrDefaultAsync(x => x.Hash == req.Hash, ct);

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
