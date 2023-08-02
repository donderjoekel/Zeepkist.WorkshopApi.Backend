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
            Medals = level.MedalsNavigation?.ToResponseModel() ?? new MedalsResponseModel()
            {
                Id = level.Medals
            },
            ImageUrl = level.Image,
            WorkshopId = level.WorkshopId.ToString(CultureInfo.InvariantCulture),
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

    public static MedalsResponseModel ToResponseModel(this MedalModel medalTimes)
    {
        return new MedalsResponseModel()
        {
            Id = medalTimes.Id,
            IsValid = medalTimes.IsValid,
            Validation = medalTimes.Validation,
            Gold = medalTimes.Gold,
            Silver = medalTimes.Silver,
            Bronze = medalTimes.Bronze
        };
    }

    public static MedalModel ToModel(this MedalsResponseModel responseModel)
    {
        return new MedalModel()
        {
            Id = responseModel.Id,
            Validation = responseModel.Validation,
            Gold = responseModel.Gold,
            Silver = responseModel.Silver,
            Bronze = responseModel.Bronze
        };
    }
}
