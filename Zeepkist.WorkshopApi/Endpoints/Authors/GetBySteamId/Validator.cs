namespace TNRD.Zeepkist.WorkshopApi.Endpoints.Authors.GetBySteamId;

public class Validator : Validator<RequestModel>
{
    public Validator()
    {
        RuleFor(x => x.Id).NotNull().NotEmpty().Custom((s, context) =>
        {
            if (!ulong.TryParse(s, out _))
                context.AddFailure("SteamId must be a number (ulong) (64-bit unsigned integer).");
        });
    }
}
