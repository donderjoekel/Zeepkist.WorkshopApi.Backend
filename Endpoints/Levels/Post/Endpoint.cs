using Microsoft.EntityFrameworkCore.ChangeTracking;
using TNRD.Zeepkist.WorkshopApi.Backend.ResponseModels;
using TNRD.Zeepkist.WorkshopApi.Database;
using TNRD.Zeepkist.WorkshopApi.Database.Models;

namespace TNRD.Zeepkist.WorkshopApi.Backend.Endpoints.Levels.Post;

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
        Level model = new()
        {
            WorkshopId = ulong.Parse(req.WorkshopId),
            AuthorId = ulong.Parse(req.AuthorId),
            Name = req.Name,
            CreatedAt = req.CreatedAt,
            UpdatedAt = req.UpdatedAt,
            ImageUrl = req.ImageUrl,
            FileUrl = req.FileUrl,
            FileUid = req.FileUid,
            FileHash = req.FileHash,
            FileAuthor = req.FileAuthor,
            MetadataId = req.MetadataId
        };

        EntityEntry<Level> entry = await context.Levels.AddAsync(model, ct);
        await context.SaveChangesAsync(ct);
        await SendOkAsync(entry.Entity.ToResponseModel(), ct);
    }
}
