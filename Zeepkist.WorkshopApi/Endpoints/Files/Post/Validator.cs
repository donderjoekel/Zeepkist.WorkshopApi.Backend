namespace Zeepkist.WorkshopApi.Endpoints.Files.Post;

public class Validator : Validator<RequestModel>
{
    public Validator()
    {
        RuleFor(x => x.Hash).NotNull().NotEmpty();
        RuleFor(x => x.Data).NotNull().NotEmpty();
        RuleFor(x => x.Uid).NotNull().NotEmpty();
        RuleFor(x => x.Author).NotNull().NotEmpty();
    }
}
