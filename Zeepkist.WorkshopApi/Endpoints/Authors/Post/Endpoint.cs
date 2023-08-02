using System.Net;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using TNRD.Zeepkist.WorkshopApi.Db;
using TNRD.Zeepkist.WorkshopApi.Db.Models;
using TNRD.Zeepkist.WorkshopApi.ResponseModels;

namespace TNRD.Zeepkist.WorkshopApi.Endpoints.Authors.Post;

public class Endpoint : Endpoint<RequestModel, AuthorResponseModel>
{
    private readonly ZworpshopContext context;

    public Endpoint(ZworpshopContext context)
    {
        this.context = context;
    }

    public override void Configure()
    {
        Post("authors");
        Description(b => b.ExcludeFromDescription());
    }

    public override async Task HandleAsync(RequestModel req, CancellationToken ct)
    {
        ulong steamId = ulong.Parse(req.SteamId);
        if (await context.Authors.AnyAsync(x => x.SteamId == steamId, ct))
        {
            await SendAsync(null, (int)HttpStatusCode.Conflict, ct);
            return;
        }

        AuthorModel model = new()
        {
            DisplayName = req.Name,
            SteamId = steamId
        };

        EntityEntry<AuthorModel> entry = await context.Authors.AddAsync(model, ct);
        await context.SaveChangesAsync(ct);
        await SendOkAsync(entry.Entity.ToResponseModel(), ct);
    }
}
