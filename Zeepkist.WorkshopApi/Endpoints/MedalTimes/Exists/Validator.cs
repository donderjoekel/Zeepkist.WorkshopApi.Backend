namespace Zeepkist.WorkshopApi.Endpoints.MedalTimes.Exists;

public class Validator : Validator<RequestModel>
{
    public Validator()
    {
        RuleFor(x => x.Validation).GreaterThanOrEqualTo(0);
        RuleFor(x => x.Gold).GreaterThanOrEqualTo(0);
        RuleFor(x => x.Silver).GreaterThanOrEqualTo(0);
        RuleFor(x => x.Bronze).GreaterThanOrEqualTo(0);
    }
}
