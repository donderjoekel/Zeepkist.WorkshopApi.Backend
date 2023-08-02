using Microsoft.EntityFrameworkCore;
using TNRD.Zeepkist.WorkshopApi.Db;
using TNRD.Zeepkist.WorkshopApi.Db.Models;
using TNRD.Zeepkist.WorkshopApi.RequestModels;
using TNRD.Zeepkist.WorkshopApi.ResponseModels;

namespace TNRD.Zeepkist.WorkshopApi.Endpoints.MedalTimes.Get;

public class Endpoint : Endpoint<IdRequestModel, MedalsResponseModel>
{
    private readonly ZworpshopContext context;

    public Endpoint(ZworpshopContext context)
    {
        this.context = context;
    }

    public override void Configure()
    {
        Get("medals/{id}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(IdRequestModel req, CancellationToken ct)
    {
        MedalModel? result = await context.Medals.FirstOrDefaultAsync(x => x.Id == req.Id, ct);

        if (result != null)
        {
            await SendOkAsync(result.ToResponseModel(), ct);
        }
        else
        {
            await SendNotFoundAsync(ct);
        }
    }
}
