namespace Zeepkist.WorkshopApi.Endpoints.Levels.Post;

public class RequestModel
{
    public string Name { get; set; } = null!;
    public string WorkshopId { get; set; } = null!;
    public int Author { get; set; }
    public int File { get; set; }
    public int Medals { get; set; }
    public string ImageUrl { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
