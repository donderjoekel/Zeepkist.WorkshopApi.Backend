using TNRD.Zeepkist.WorkshopApi.Backend.Validators;

namespace TNRD.Zeepkist.WorkshopApi.Backend.Endpoints.Levels.GetByWorkshopId;

public class Validator : Validator<RequestModel>
{
    public Validator()
    {
        RuleFor(x => x.Id).NotNull().NotEmpty().IsUnsignedLong();
    }
}
