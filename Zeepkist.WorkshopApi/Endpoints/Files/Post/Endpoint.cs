using FluentResults;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Zeepkist.WorkshopApi.Db;
using Zeepkist.WorkshopApi.Db.Models;
using Zeepkist.WorkshopApi.Google;
using Zeepkist.WorkshopApi.ResponseModels;

namespace Zeepkist.WorkshopApi.Endpoints.Files.Post;

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
            Author = req.Author
        };

        EntityEntry<FileModel> entry = context.Files.Add(model);
        await context.SaveChangesAsync(ct);
        await SendOkAsync(entry.Entity.ToResponseModel(), ct);
    }
}
