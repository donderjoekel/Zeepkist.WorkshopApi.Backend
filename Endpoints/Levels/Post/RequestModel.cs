namespace TNRD.Zeepkist.WorkshopApi.Backend.Endpoints.Levels.Post;

public class RequestModel
{
    public string WorkshopId { get; set; } = null!;
    public string AuthorId { get; set; } = null!;
    public string Name { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string ImageUrl { get; set; } = null!;
    public string FileUrl { get; set; } = null!;
    public string FileUid { get; set; } = null!;
    public string FileHash { get; set; } = null!;
    public string FileAuthor { get; set; } = null!;
}
