﻿using Microsoft.EntityFrameworkCore;

using Zeepkist.WorkshopApi.Db;
using Zeepkist.WorkshopApi.Db.Models;
using Zeepkist.WorkshopApi.RequestModels;
using Zeepkist.WorkshopApi.ResponseModels;

namespace Zeepkist.WorkshopApi.Endpoints.Files.Get;

public class Endpoint : Endpoint<IdRequestModel, FileResponseModel>
{
    private readonly ZworpshopContext context;

    public Endpoint(ZworpshopContext context)
    {
        this.context = context;
    }

    public override void Configure()
    {
        Get("files/{id}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(IdRequestModel req, CancellationToken ct)
    {
        FileModel? result = await context.Files.FirstOrDefaultAsync(x => x.Id == req.Id, ct);

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