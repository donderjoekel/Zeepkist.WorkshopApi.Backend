using Microsoft.EntityFrameworkCore;
using TNRD.Zeepkist.WorkshopApi.Db;
using TNRD.Zeepkist.WorkshopApi.Db.Models;
using TNRD.Zeepkist.WorkshopApi.ResponseModels;

namespace TNRD.Zeepkist.WorkshopApi.Endpoints.MedalTimes.Exists;

public class Endpoint : Endpoint<RequestModel, MedalsResponseModel>
{
    private readonly ZworpshopContext context;

    public Endpoint(ZworpshopContext context)
    {
        this.context = context;
    }

    public override void Configure()
    {
        Get("medals/exists");
    }

    public override async Task HandleAsync(RequestModel req, CancellationToken ct)
    {
        const float tolerance = 0.0001f;

        MedalModel? model = await context.Medals.FirstOrDefaultAsync(x =>
                x.IsValid == req.IsValid &&
                Math.Abs(x.Validation - req.Validation) < tolerance &&
                Math.Abs(x.Gold - req.Gold) < tolerance &&
                Math.Abs(x.Silver - req.Silver) < tolerance &&
                Math.Abs(x.Bronze - req.Bronze) < tolerance,
            ct);

        if (model != null)
        {
            await SendOkAsync(model.ToResponseModel(), ct);
        }
        else
        {
            await SendNotFoundAsync(ct);
        }
    }
}
