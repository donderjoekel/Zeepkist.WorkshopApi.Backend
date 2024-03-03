namespace TNRD.Zeepkist.WorkshopApi.Backend.Endpoints.Levels.GetByUid;

public class Validator : Validator<RequestModel>
{
    public Validator()
    {
        RuleFor(x => x.Uid).NotNull().NotEmpty();
    }
}
