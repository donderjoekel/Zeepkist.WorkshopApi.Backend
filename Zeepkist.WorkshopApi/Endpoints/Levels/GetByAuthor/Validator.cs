using TNRD.Zeepkist.WorkshopApi.Validators;

namespace TNRD.Zeepkist.WorkshopApi.Endpoints.Levels.GetByAuthor;

public class Validator : Validator<RequestModel>
{
    public Validator()
    {
        RuleFor(x => x.Id).NotNull().NotEmpty().IsUnsignedLong();
    }
}
