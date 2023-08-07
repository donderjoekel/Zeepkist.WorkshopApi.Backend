namespace TNRD.Zeepkist.WorkshopApi.Endpoints.Levels.Post;

public class RequestModel
{
    public string Name { get; set; } = null!;
    public string WorkshopId { get; set; } = null!;
    public string AuthorId { get; set; } = null!;
    public int File { get; set; }
    public string ImageUrl { get; set; } = null!;
    public bool Valid { get; set; }
    public float Validation { get; set; }
    public float Gold { get; set; }
    public float Silver { get; set; }
    public float Bronze { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
