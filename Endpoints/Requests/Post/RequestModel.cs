namespace TNRD.Zeepkist.WorkshopApi.Backend.Endpoints.Requests.Post;

public class RequestModel
{
    public string WorkshopId { get; set; } = null!;
    public string? Uid { get; set; }
    public string? Hash { get; set; }
}
