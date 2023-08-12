using Microsoft.EntityFrameworkCore;
using TNRD.Zeepkist.WorkshopApi.Backend.Db;
using TNRD.Zeepkist.WorkshopApi.Backend.Db.Models;
using TNRD.Zeepkist.WorkshopApi.Backend.ResponseModels;

namespace TNRD.Zeepkist.WorkshopApi.Backend.Endpoints.Levels.GetByAuthor;

public class Endpoint : Endpoint<RequestModel, IEnumerable<LevelResponseModel>>
{
    private readonly ZworpshopContext context;

    public Endpoint(ZworpshopContext context)
    {
        this.context = context;
    }

    public override void Configure()
    {
        Get("levels/author/{id}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(RequestModel req, CancellationToken ct)
    {
        ulong authorId = ulong.Parse(req.Id);

        IQueryable<LevelModel> query = context.Levels.AsNoTracking()
            .Where(x => x.AuthorId == authorId);

        if (!req.IncludeReplaced)
        {
            query = query.Where(x => x.ReplacedBy == null);
        }

        List<LevelModel> result = await query
            .OrderBy(x => x.Id)
            .ToListAsync(ct);

        if (result.Count > 0)
        {
            await SendOkAsync(result.Select(x => x.ToResponseModel()), ct);
        }
        else
        {
            await SendNotFoundAsync(ct);
        }
    }
}
