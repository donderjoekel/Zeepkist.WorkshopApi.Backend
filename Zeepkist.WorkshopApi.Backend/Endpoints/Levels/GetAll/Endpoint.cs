using Microsoft.EntityFrameworkCore;
using TNRD.Zeepkist.WorkshopApi.Backend.Db;
using TNRD.Zeepkist.WorkshopApi.Backend.Db.Models;
using TNRD.Zeepkist.WorkshopApi.Backend.RequestModels;
using TNRD.Zeepkist.WorkshopApi.Backend.ResponseModels;

namespace TNRD.Zeepkist.WorkshopApi.Backend.Endpoints.Levels.GetAll;

public class Endpoint : Endpoint<RequestModel, IEnumerable<LevelResponseModel>>
{
    private readonly ZworpshopContext context;

    public Endpoint(ZworpshopContext context)
    {
        this.context = context;
    }

    public override void Configure()
    {
        Get("levels");
        AllowAnonymous();
    }

    public override async Task HandleAsync(RequestModel req, CancellationToken ct)
    {
        IQueryable<LevelModel> query = context.Levels
            .AsNoTracking();

        if (!req.IncludeReplaced)
        {
            query = query.Where(x => x.ReplacedBy == null);
        }

        if (!req.IncludeDeleted)
        {
            query = query.Where(x => x.Deleted == false);
        }

        if (!string.IsNullOrEmpty(req.DateCreated))
        {
            if (!long.TryParse(req.DateCreated, out long dateCreated))
                ThrowError("Unable to parse date created. Is it in unix time seconds?");

            DateTime utcDateTime = DateTimeOffset.FromUnixTimeSeconds(dateCreated).UtcDateTime;
            query = query.Where(x => x.CreatedAt == utcDateTime);
        }

        if (!string.IsNullOrEmpty(req.DateUpdated))
        {
            if (!long.TryParse(req.DateUpdated, out long dateUpdated))
                ThrowError("Unable to parse date updated. Is it in unix time seconds?");

            DateTime utcDateTime = DateTimeOffset.FromUnixTimeSeconds(dateUpdated).UtcDateTime;
            query = query.Where(x => x.UpdatedAt == utcDateTime);
        }

        await SendOkAsync(await query
                .OrderBy(x => x.Id)
                .Skip(req.Offset)
                .Take(req.Limit)
                .Select(x => x.ToResponseModel())
                .ToListAsync(ct),
            ct);
    }
}
