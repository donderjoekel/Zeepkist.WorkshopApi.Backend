using Microsoft.EntityFrameworkCore.ChangeTracking;
using Zeepkist.WorkshopApi.Db;
using Zeepkist.WorkshopApi.Db.Models;
using Zeepkist.WorkshopApi.RequestModels;
using Zeepkist.WorkshopApi.ResponseModels;

namespace Zeepkist.WorkshopApi.Endpoints.MedalTimes.Post;

public class Endpoint : Endpoint<RequestModel, MedalsResponseModel>
{
    private readonly ZworpshopContext context;

    public Endpoint(ZworpshopContext context)
    {
        this.context = context;
    }

    public override void Configure()
    {
        Post("medals");
        Description(b => b.ExcludeFromDescription());
    }

    public override async Task HandleAsync(RequestModel req, CancellationToken ct)
    {
        MedalModel model = new()
        {
            IsValid = req.IsValid,
            Validation = req.Validation,
            Gold = req.Gold,
            Silver = req.Silver,
            Bronze = req.Bronze
        };

        EntityEntry<MedalModel> entry = await context.Medals.AddAsync(model, ct);
        await context.SaveChangesAsync(ct);
        await SendOkAsync(entry.Entity.ToResponseModel(), ct);
    }
}
