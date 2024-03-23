using Microsoft.EntityFrameworkCore.ChangeTracking;
using TNRD.Zeepkist.WorkshopApi.Backend.ResponseModels;
using TNRD.Zeepkist.WorkshopApi.Database;

namespace TNRD.Zeepkist.WorkshopApi.Backend.Endpoints.Meta.Post;

public class Endpoint : Endpoint<RequestModel, MetadataResponseModel>
{
    private readonly ZworpshopContext context;

    public Endpoint(ZworpshopContext context)
    {
        this.context = context;
    }

    public override void Configure()
    {
        Post("metadata");
        Description(b => b.ExcludeFromDescription());
    }

    public override async Task HandleAsync(RequestModel req, CancellationToken ct)
    {
        Database.Models.Metadata model = new()
        {
            Hash = req.Hash,
            Checkpoints = req.Checkpoints,
            Blocks = req.Blocks,
            Valid = req.Valid,
            Validation = req.Validation,
            Gold = req.Gold,
            Silver = req.Silver,
            Bronze = req.Bronze,
            Ground = req.Ground,
            Skybox = req.Skybox
        };

        EntityEntry<Database.Models.Metadata> entry = await context.Metadata.AddAsync(model, ct);
        await context.SaveChangesAsync(ct);
        await SendOkAsync(entry.Entity.ToResponseModel(), ct);
    }
}
