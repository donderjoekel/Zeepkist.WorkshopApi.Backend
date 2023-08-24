using Microsoft.EntityFrameworkCore;
using TNRD.Zeepkist.WorkshopApi.Backend.Db;
using TNRD.Zeepkist.WorkshopApi.Backend.Db.Models;
using TNRD.Zeepkist.WorkshopApi.Backend.RequestModels;
using TNRD.Zeepkist.WorkshopApi.Backend.ResponseModels;

namespace TNRD.Zeepkist.WorkshopApi.Backend.Endpoints.Levels.GetRandom;

public class Endpoint : Endpoint<GetRandomRequestModel, IEnumerable<LevelResponseModel>>
{
    private readonly ZworpshopContext context;

    public Endpoint(ZworpshopContext context)
    {
        this.context = context;
    }

    public override void Configure()
    {
        Get("levels/random");
        AllowAnonymous();
    }

    public override async Task HandleAsync(GetRandomRequestModel req, CancellationToken ct)
    {
        List<LevelModel> levels = await context.Levels.AsNoTracking()
            .OrderBy(x => EF.Functions.Random())
            .Take(req.Amount)
            .ToListAsync(ct);

        levels = levels.DistinctBy(x => x.FileHash).ToList();

        while (levels.Count != req.Amount)
        {
            List<LevelModel> extraLevels = await context.Levels.AsNoTracking()
                .OrderBy(x => EF.Functions.Random())
                .Take(req.Amount)
                .ToListAsync(ct);

            extraLevels = extraLevels.DistinctBy(x => x.FileHash).ToList();

            int delta = req.Amount - levels.Count;
            for (int i = 0; i < delta; i++)
            {
                levels.Add(extraLevels[i]);
            }

            levels = levels.DistinctBy(x => x.FileHash).ToList();
        }

        await SendOkAsync(levels.Select(x => x.ToResponseModel()), ct);
    }
}
