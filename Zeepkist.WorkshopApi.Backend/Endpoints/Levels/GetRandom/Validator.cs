using TNRD.Zeepkist.WorkshopApi.Backend.RequestModels;

namespace TNRD.Zeepkist.WorkshopApi.Backend.Endpoints.Levels.GetRandom;

public class Validator : Validator<GetRandomRequestModel>
{
    public Validator()
    {
        RuleFor(x => x.Amount).GreaterThanOrEqualTo(1).LessThanOrEqualTo(100);
    }
}
