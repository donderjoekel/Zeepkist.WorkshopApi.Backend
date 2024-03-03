using Microsoft.EntityFrameworkCore;
using TNRD.Zeepkist.WorkshopApi.Database;
using TNRD.Zeepkist.WorkshopApi.Backend.ResponseModels;
using TNRD.Zeepkist.WorkshopApi.Database;
using TNRD.Zeepkist.WorkshopApi.Database.Models;

namespace TNRD.Zeepkist.WorkshopApi.Backend.Endpoints.Levels.GetByHashes;

public class Endpoint : Endpoint<RequestModel, IEnumerable<LevelResponseModel>>
{
    private readonly ZworpshopContext context;

    public Endpoint(ZworpshopContext context)
    {
        this.context = context;
    }

    public override void Configure()
    {
        Get("levels/hashes/{hashes}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(RequestModel req, CancellationToken ct)
    {
        string[] hashes = req.Hashes.Split(',');

        IQueryable<Level>? query = context.Levels.AsNoTracking()
            .Where(x => hashes.Contains(x.FileHash));

        if (!req.IncludeReplaced)
        {
            query = query.Where(x => x.ReplacedBy == null);
        }

        if (!req.IncludeDeleted)
        {
            query = query.Where(x => x.Deleted == false);
        }

        List<Level> result = await query.ToListAsync(ct);

        await SendOkAsync(result.Select(x => x.ToResponseModel()), ct);
    }
}
