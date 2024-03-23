namespace TNRD.Zeepkist.WorkshopApi.Backend.Endpoints.Meta.Post;

public class Validator : Validator<RequestModel>
{
    public Validator()
    {
        RuleFor(x => x.Hash).NotNull().NotEmpty();
        RuleFor(x => x.Checkpoints).NotNull().GreaterThanOrEqualTo(0);
        RuleFor(x => x.Blocks).NotNull().NotEmpty();
        RuleFor(x => x.Valid).NotNull();
        RuleFor(x => x.Validation).NotNull();
        RuleFor(x => x.Gold).NotNull();
        RuleFor(x => x.Silver).NotNull();
        RuleFor(x => x.Bronze).NotNull();
        RuleFor(x => x.Ground).NotNull().GreaterThanOrEqualTo(-1);
        RuleFor(x => x.Skybox).NotNull().GreaterThanOrEqualTo(0);
    }
}
