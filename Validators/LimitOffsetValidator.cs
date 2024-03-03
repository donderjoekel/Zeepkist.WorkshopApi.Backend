using TNRD.Zeepkist.WorkshopApi.Backend.RequestModels;

namespace TNRD.Zeepkist.WorkshopApi.Backend.Validators;

public class LimitOffsetValidator : Validator<LimitOffsetRequestModel>
{
    public LimitOffsetValidator()
    {
        RuleFor(x => x.Limit).GreaterThanOrEqualTo(0).LessThanOrEqualTo(100);
        RuleFor(x => x.Offset).GreaterThanOrEqualTo(0);
    }
}
