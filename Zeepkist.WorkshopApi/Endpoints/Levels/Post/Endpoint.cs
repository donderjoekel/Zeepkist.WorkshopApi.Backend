using Microsoft.EntityFrameworkCore.ChangeTracking;
using TNRD.Zeepkist.WorkshopApi.Db;
using TNRD.Zeepkist.WorkshopApi.Db.Models;
using TNRD.Zeepkist.WorkshopApi.ResponseModels;

namespace TNRD.Zeepkist.WorkshopApi.Endpoints.Levels.Post;

public class Endpoint : Endpoint<RequestModel, LevelResponseModel>
{
    private readonly ZworpshopContext context;

    public Endpoint(ZworpshopContext context)
    {
        this.context = context;
    }

    public override void Configure()
    {
        Post("levels");
        Description(b => b.ExcludeFromDescription());
    }

    public override async Task HandleAsync(RequestModel req, CancellationToken ct)
    {
        LevelModel model = new()
        {
            Author = req.Author,
            File = req.File,
            Name = req.Name,
            Image = req.ImageUrl,
            CreatedAt = req.CreatedAt,
            UpdatedAt = req.UpdatedAt,
            WorkshopId = ulong.Parse(req.WorkshopId),
            Valid = req.Valid,
            Validation = req.Validation,
            Gold = req.Gold,
            Silver = req.Silver,
            Bronze = req.Bronze
        };

        EntityEntry<LevelModel> entry = await context.Levels.AddAsync(model, ct);
        await context.SaveChangesAsync(ct);
        await SendOkAsync(entry.Entity.ToResponseModel(), ct);
    }
}
