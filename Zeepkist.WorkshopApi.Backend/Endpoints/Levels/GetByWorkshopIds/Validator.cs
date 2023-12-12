namespace TNRD.Zeepkist.WorkshopApi.Backend.Endpoints.Levels.GetByWorkshopIds;

public class Validator : Validator<RequestModel>
{
    public Validator()
    {
        RuleFor(x => x.Ids).NotNull().NotEmpty();
    }
}
