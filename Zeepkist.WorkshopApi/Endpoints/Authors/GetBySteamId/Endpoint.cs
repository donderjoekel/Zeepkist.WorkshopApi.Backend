using Microsoft.EntityFrameworkCore;
using TNRD.Zeepkist.WorkshopApi.Db;
using TNRD.Zeepkist.WorkshopApi.Db.Models;
using TNRD.Zeepkist.WorkshopApi.ResponseModels;

namespace TNRD.Zeepkist.WorkshopApi.Endpoints.Authors.GetBySteamId;

public class Endpoint : Endpoint<RequestModel, AuthorResponseModel>
{
    private readonly ZworpshopContext context;

    public Endpoint(ZworpshopContext context)
    {
        this.context = context;
    }

    public override void Configure()
    {
        Get("authors/steam/{id}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(RequestModel req, CancellationToken ct)
    {
        ulong steamId = ulong.Parse(req.Id);
        AuthorModel? model = await context.Authors.AsNoTracking().FirstOrDefaultAsync(x => x.SteamId == steamId, ct);

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
