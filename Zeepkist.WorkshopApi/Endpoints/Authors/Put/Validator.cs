using TNRD.Zeepkist.WorkshopApi.RequestModels;
using TNRD.Zeepkist.WorkshopApi.ResponseModels;

namespace TNRD.Zeepkist.WorkshopApi.Endpoints.Authors.Put;

public class Validator : Validator<PutRequestModel<AuthorResponseModel>>
{
    public Validator()
    {
        RuleFor(x => x.Model).NotNull();
        RuleFor(x => x.Model.SteamId).Custom((input, context) =>
        {
            if (!ulong.TryParse(input, out _))
            {
                context.AddFailure("SteamId must be a number (ulong) (64-bit unsigned integer).");
            }
        });
        RuleFor(x => x.Id).GreaterThanOrEqualTo(0).Equal(m => m.Model.Id);
    }
}
