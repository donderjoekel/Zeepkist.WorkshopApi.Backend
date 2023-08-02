namespace TNRD.Zeepkist.WorkshopApi.Endpoints.Files.GetByHash;

public class Validator : Validator<RequestModel>
{
    public Validator()
    {
        RuleFor(x => x.Hash).NotNull().NotEmpty();
    }
}
