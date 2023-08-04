using TNRD.Zeepkist.WorkshopApi.RequestModels;

namespace TNRD.Zeepkist.WorkshopApi.Validators;

public class LimitOffsetValidator : Validator<LimitOffsetRequestModel>
{
    public LimitOffsetValidator()
    {
        RuleFor(x => x.Limit).GreaterThanOrEqualTo(0).LessThanOrEqualTo(100);
        RuleFor(x => x.Offset).GreaterThanOrEqualTo(0);
    }
}
