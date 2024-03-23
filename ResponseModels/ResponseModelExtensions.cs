using System.Globalization;
using TNRD.Zeepkist.WorkshopApi.Database.Models;

namespace TNRD.Zeepkist.WorkshopApi.Backend.ResponseModels;

public static class ResponseModelExtensions
{
    public static LevelResponseModel ToResponseModel(this Level level)
    {
        return new LevelResponseModel
        {
            Id = level.Id,
            ReplacedBy = level.ReplacedBy,
            WorkshopId = level.WorkshopId.ToString(CultureInfo.InvariantCulture),
            AuthorId = level.AuthorId.ToString(CultureInfo.InvariantCulture),
            Name = level.Name,
            CreatedAt = level.CreatedAt,
            UpdatedAt = level.UpdatedAt,
            ImageUrl = level.ImageUrl,
            FileUrl = level.FileUrl,
            FileUid = level.FileUid,
            FileHash = level.FileHash,
            FileAuthor = level.FileAuthor,
            Deleted = level.Deleted,
        };
    }
}
