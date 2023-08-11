namespace TNRD.Zeepkist.WorkshopApi.Backend.Endpoints.Levels.Put;

public class Validator : Validator<RequestModel>
{
    public Validator()
    {
        RuleFor(x => x.Id).NotEmpty().NotNull().GreaterThanOrEqualTo(0);
        RuleFor(x => x.Replacement).NotEmpty().NotNull().GreaterThanOrEqualTo(0);
    }
}
