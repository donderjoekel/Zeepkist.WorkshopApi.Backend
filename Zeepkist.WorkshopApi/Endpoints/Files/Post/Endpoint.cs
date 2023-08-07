using FluentResults;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using TNRD.Zeepkist.WorkshopApi.Db;
using TNRD.Zeepkist.WorkshopApi.Db.Models;
using TNRD.Zeepkist.WorkshopApi.Google;
using TNRD.Zeepkist.WorkshopApi.ResponseModels;

namespace TNRD.Zeepkist.WorkshopApi.Endpoints.Files.Post;

public class Endpoint : Endpoint<RequestModel, FileResponseModel>
{
    private readonly ZworpshopContext context;
    private readonly IUploadService uploadService;

    public Endpoint(ZworpshopContext context, IUploadService uploadService)
    {
        this.context = context;
        this.uploadService = uploadService;
    }

    public override void Configure()
    {
        Post("files");
        Description(b => b.ExcludeFromDescription());
    }

    public override async Task HandleAsync(RequestModel req, CancellationToken ct)
    {
        string identifier = Guid.NewGuid().ToString();

        Result<string> result = await uploadService.UploadFile(identifier, req.Data, ct);

        if (result.IsFailed)
        {
            Logger.LogError("Failed to upload file: {Result}", result);
            ThrowError("Failed to upload file");
        }

        if (string.IsNullOrEmpty(result.Value))
        {
            Logger.LogError("Failed to upload file: {Result}", result);
            ThrowError("Failed to upload file");
        }

        FileModel model = new()
        {
            Hash = req.Hash,
            Url = result.Value,
            Uid = req.Uid,
            Author = req.Author,
            ModioId = req.ModioId
        };

        EntityEntry<FileModel> entry = context.Files.Add(model);
        await context.SaveChangesAsync(ct);
        await SendOkAsync(entry.Entity.ToResponseModel(), ct);
    }
}
