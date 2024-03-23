namespace TNRD.Zeepkist.WorkshopApi.Backend.Endpoints.Meta.Get;

public class Validator : Validator<RequestModel>
{
    public Validator()
    {
        RuleFor(x => x.Hash).NotNull().NotEmpty();
    }
}
