namespace TNRD.Zeepkist.WorkshopApi.Endpoints.Levels.Exists;

public class Validator : Validator<RequestModel>
{
    public Validator()
    {
        RuleFor(x => x.Name).NotNull().NotEmpty();
        RuleFor(x => x.Author).GreaterThanOrEqualTo(0);
        RuleFor(x => x.File).GreaterThanOrEqualTo(0);
        RuleFor(x => x.Medals).GreaterThanOrEqualTo(0);
        RuleFor(x => x.WorkshopId).NotNull().NotEmpty().Custom((input, context) =>
        {
            if (!ulong.TryParse(input, out _))
            {
                context.AddFailure("WorkshopId", "WorkshopId must be a number (ulong) (64-bit unsigned integer).");
            }
        });
    }
}
