﻿using Microsoft.EntityFrameworkCore;
using TNRD.Zeepkist.WorkshopApi.Backend.RequestModels;
using TNRD.Zeepkist.WorkshopApi.Backend.ResponseModels;
using TNRD.Zeepkist.WorkshopApi.Database;
using TNRD.Zeepkist.WorkshopApi.Database.Models;

namespace TNRD.Zeepkist.WorkshopApi.Backend.Endpoints.Meta.Get;

public class Endpoint : Endpoint<IdRequestModel, MetadataResponseModel>
{
    private readonly ZworpshopContext context;
    
    public Endpoint(ZworpshopContext context)
    {
        this.context = context;
    }
    
    public override void Configure()
    {
        Get("metadata/{id}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(IdRequestModel req, CancellationToken ct)
    {
        Metadata? result = await context.Metadata.AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == req.Id, ct);

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
