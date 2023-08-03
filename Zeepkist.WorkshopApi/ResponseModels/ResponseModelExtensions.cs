using System.Globalization;
using TNRD.Zeepkist.WorkshopApi.Db.Models;

namespace TNRD.Zeepkist.WorkshopApi.ResponseModels;

public static class ResponseModelExtensions
{
    public static AuthorResponseModel ToResponseModel(this AuthorModel author)
    {
        return new AuthorResponseModel
        {
            Id = author.Id,
            Name = author.DisplayName,
            SteamId = author.SteamId.ToString(CultureInfo.InvariantCulture)
        };
    }

    public static LevelResponseModel ToResponseModel(this LevelModel level)
    {
        return new LevelResponseModel
        {
            Id = level.Id,
            Name = level.Name,
            Author = level.AuthorNavigation?.ToResponseModel() ?? new AuthorResponseModel()
            {
                Id = level.Author
            },
            File = level.FileNavigation?.ToResponseModel() ?? new FileResponseModel()
            {
                Id = level.File
            },
            ImageUrl = level.Image,
            WorkshopId = level.WorkshopId.ToString(CultureInfo.InvariantCulture),
            Valid = level.Valid,
            Validation = level.Validation,
            Gold = level.Gold,
            Silver = level.Silver,
            Bronze = level.Bronze,
            CreatedAt = level.CreatedAt,
            UpdatedAt = level.UpdatedAt
        };
    }

    public static FileResponseModel ToResponseModel(this FileModel file)
    {
        return new FileResponseModel()
        {
            Id = file.Id,
            Hash = file.Hash,
            Url = file.Url,
            Author = file.Author,
            Uid = file.Uid
        };
    }
}
