using TNRD.Zeepkist.WorkshopApi.Validators;

namespace TNRD.Zeepkist.WorkshopApi.Endpoints.Levels.Post;

public class Validator : Validator<RequestModel>
{
    public Validator()
    {
        RuleFor(x => x.WorkshopId).NotNull().NotEmpty().IsUnsignedLong();
        RuleFor(x => x.AuthorId).NotNull().NotEmpty().IsUnsignedLong();
        RuleFor(x => x.Name).NotNull().NotEmpty();
        RuleFor(x => x.CreatedAt).NotNull().NotEmpty().GreaterThanOrEqualTo(new DateTime(2021, 1, 1));
        RuleFor(x => x.UpdatedAt).NotNull().NotEmpty().GreaterThanOrEqualTo(new DateTime(2021, 1, 1));
        RuleFor(x => x.ImageUrl).NotNull().NotEmpty();
        RuleFor(x => x.FileUrl).NotNull().NotEmpty();
        RuleFor(x => x.FileUid).NotNull().NotEmpty();
        RuleFor(x => x.FileHash).NotNull().NotEmpty();
        RuleFor(x => x.FileAuthor).NotNull().NotEmpty();
        RuleFor(x => x.Validation).NotNull().NotEmpty();
        RuleFor(x => x.Gold).NotNull().NotEmpty();
        RuleFor(x => x.Silver).NotNull().NotEmpty();
        RuleFor(x => x.Bronze).NotNull().NotEmpty();
    }
}
