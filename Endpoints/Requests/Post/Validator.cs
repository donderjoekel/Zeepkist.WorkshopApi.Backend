namespace TNRD.Zeepkist.WorkshopApi.Backend.Endpoints.Requests.Post;

public class Validator : Validator<RequestModel>
{
    public Validator()
    {
        RuleFor(x => x.WorkshopId).NotEmpty().Custom((s, context) =>
        {
            if (!decimal.TryParse(s, out decimal _))
            {
                context.AddFailure("WorkshopId", "WorkshopId must be a number");
            }
        });
    }
}
