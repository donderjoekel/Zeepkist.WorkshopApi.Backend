namespace TNRD.Zeepkist.WorkshopApi.Backend.Endpoints.Levels.GetByHash;

public class Validator : Validator<RequestModel>
{
    public Validator()
    {
        RuleFor(x => x.Hash).NotNull().NotEmpty();
    }
}
