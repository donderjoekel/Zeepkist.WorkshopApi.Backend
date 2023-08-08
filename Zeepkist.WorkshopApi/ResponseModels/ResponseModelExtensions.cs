using System.Globalization;
using TNRD.Zeepkist.WorkshopApi.Db.Models;

namespace TNRD.Zeepkist.WorkshopApi.ResponseModels;

public static class ResponseModelExtensions
{
    public static LevelResponseModel ToResponseModel(this LevelModel level)
    {
        return new LevelResponseModel
        {
            Id = level.Id,
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
            Valid = level.Valid,
            Validation = level.Validation,
            Gold = level.Gold,
            Silver = level.Silver,
            Bronze = level.Bronze,
        };
    }
}
