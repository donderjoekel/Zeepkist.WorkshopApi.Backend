using System.Globalization;
using TNRD.Zeepkist.WorkshopApi.Database.Models;

namespace TNRD.Zeepkist.WorkshopApi.Backend.ResponseModels;

public static class ResponseModelExtensions
{
    public static LevelResponseModel ToResponseModel(this Level model)
    {
        return new LevelResponseModel
        {
            Id = model.Id,
            ReplacedBy = model.ReplacedBy,
            WorkshopId = model.WorkshopId.ToString(CultureInfo.InvariantCulture),
            AuthorId = model.AuthorId.ToString(CultureInfo.InvariantCulture),
            Name = model.Name,
            CreatedAt = model.CreatedAt,
            UpdatedAt = model.UpdatedAt,
            ImageUrl = model.ImageUrl,
            FileUrl = model.FileUrl,
            FileUid = model.FileUid,
            FileHash = model.FileHash,
            FileAuthor = model.FileAuthor,
            Deleted = model.Deleted,
        };
    }
    
    public static MetadataResponseModel ToResponseModel(this Metadata model)
    {
        return new MetadataResponseModel
        {
            Hash = model.Hash,
            Checkpoints = model.Checkpoints,
            Blocks = model.Blocks,
            Valid = model.Valid,
            Validation = model.Validation,
            Gold = model.Gold,
            Silver = model.Silver,
            Bronze = model.Bronze,
            Ground = model.Ground,
            Skybox = model.Skybox,
        };
    }
}
