namespace TNRD.Zeepkist.WorkshopApi.Backend.Endpoints.Levels.Delete;

public class Validator : Validator<RequestModel>
{
    public Validator()
    {
        RuleFor(x => x.Id).NotEmpty().NotNull().GreaterThanOrEqualTo(0);
    }
}
