namespace TNRD.Zeepkist.WorkshopApi.ResponseModels;

public class LevelResponseModel
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string WorkshopId { get; set; } = null!;
    public string AuthorId { get; set; } = null!;
    public FileResponseModel File { get; set; } = null!;
    public bool Valid { get; set; }
    public float Validation { get; set; }
    public float Gold { get; set; }
    public float Silver { get; set; }
    public float Bronze { get; set; }
    public string ImageUrl { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
