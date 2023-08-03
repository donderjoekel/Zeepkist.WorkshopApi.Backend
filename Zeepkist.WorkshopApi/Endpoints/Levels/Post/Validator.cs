namespace TNRD.Zeepkist.WorkshopApi.Endpoints.Levels.Post;

public class Validator : Validator<RequestModel>
{
    public Validator()
    {
        RuleFor(x => x.Name).NotNull().NotEmpty();
        RuleFor(x => x.WorkshopId).NotNull().NotEmpty().Custom((input, context) =>
        {
            if (!ulong.TryParse(input, out _))
                context.AddFailure("WorkshopId must be a number (ulong) (64-bit unsigned integer).");
        });
        RuleFor(x => x.ImageUrl).NotNull().NotEmpty();
        RuleFor(x => x.Author).GreaterThanOrEqualTo(0);
        RuleFor(x => x.File).GreaterThanOrEqualTo(0);
        RuleFor(x => x.Validation).GreaterThanOrEqualTo(0);
        RuleFor(x => x.Gold).GreaterThanOrEqualTo(0);
        RuleFor(x => x.Silver).GreaterThanOrEqualTo(0);
        RuleFor(x => x.Bronze).GreaterThanOrEqualTo(0);
        RuleFor(x => x.CreatedAt).NotNull().NotEmpty();
        RuleFor(x => x.UpdatedAt).NotNull().NotEmpty();
    }
}
