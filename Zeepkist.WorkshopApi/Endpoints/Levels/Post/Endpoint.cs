using Microsoft.EntityFrameworkCore.ChangeTracking;
using Zeepkist.WorkshopApi.Db;
using Zeepkist.WorkshopApi.Db.Models;
using Zeepkist.WorkshopApi.ResponseModels;

namespace Zeepkist.WorkshopApi.Endpoints.Levels.Post;

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
    }

    public override async Task HandleAsync(RequestModel req, CancellationToken ct)
    {
        LevelModel model = new()
        {
            Author = req.Author,
            File = req.File,
            Medals = req.Medals,
            Name = req.Name,
            Image = req.ImageUrl,
            CreatedAt = req.CreatedAt,
            UpdatedAt = req.UpdatedAt,
            WorkshopId = ulong.Parse(req.WorkshopId)
        };

        EntityEntry<LevelModel> entry = await context.Levels.AddAsync(model, ct);
        await context.SaveChangesAsync(ct);
        await SendOkAsync(entry.Entity.ToResponseModel(), ct);
    }
}
