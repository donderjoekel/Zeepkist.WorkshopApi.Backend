namespace TNRD.Zeepkist.WorkshopApi.Backend.Endpoints.Levels.Put.Updated;

public class Validator : Validator<RequestModel>
{
    public Validator()
    {
        RuleFor(x => x.Id).NotEmpty().NotNull().GreaterThanOrEqualTo(0);
        RuleFor(x => x.Ticks).NotEmpty().NotNull().GreaterThanOrEqualTo(0);
    }
}
