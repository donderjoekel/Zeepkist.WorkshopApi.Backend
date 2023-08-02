using Zeepkist.WorkshopApi.RequestModels;

namespace Zeepkist.WorkshopApi.Endpoints.Authors.Post;

public class Validator : Validator<RequestModel>
{
    public Validator()
    {
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.SteamId).NotEmpty().Custom((s, context) =>
        {
            if (!ulong.TryParse(s, out _))
            {
                context.AddFailure("SteamId", "SteamId must be a number (ulong) (64-bit unsigned integer).");
            }
        });
    }
}
