namespace TNRD.Zeepkist.WorkshopApi.Endpoints.Levels.GetByHash;

public class Validator : Validator<RequestModel>
{
    public Validator()
    {
        RuleFor(x => x.Hash).NotNull().NotEmpty();
    }
}
