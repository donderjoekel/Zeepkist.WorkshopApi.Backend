using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using TNRD.Zeepkist.WorkshopApi.Db;
using TNRD.Zeepkist.WorkshopApi.Db.Models;
using TNRD.Zeepkist.WorkshopApi.RequestModels;
using TNRD.Zeepkist.WorkshopApi.ResponseModels;

namespace TNRD.Zeepkist.WorkshopApi.Endpoints.Authors.Put;

public class Endpoint : Endpoint<PutRequestModel<AuthorResponseModel>, AuthorResponseModel>
{
    private readonly ZworpshopContext context;

    public Endpoint(ZworpshopContext context)
    {
        this.context = context;
    }

    public override void Configure()
    {
        Put("authors/{id}");
        Description(b => b.ExcludeFromDescription());
    }

    public override async Task HandleAsync(PutRequestModel<AuthorResponseModel> req, CancellationToken ct)
    {
        AuthorModel model = new()
        {
            Id = req.Model.Id,
            SteamId = ulong.Parse(req.Model.SteamId),
            DisplayName = req.Model.Name
        };

        EntityEntry<AuthorModel> entry = context.Entry(model);
        entry.State = EntityState.Modified;
        await context.SaveChangesAsync(ct);
        await SendOkAsync(entry.Entity.ToResponseModel(), ct);
    }
}
