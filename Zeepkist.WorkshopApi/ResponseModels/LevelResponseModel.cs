namespace TNRD.Zeepkist.WorkshopApi.ResponseModels;

public class LevelResponseModel
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string WorkshopId { get; set; } = null!;
    public AuthorResponseModel Author { get; set; } = null!;
    public FileResponseModel File { get; set; } = null!;
    public MedalsResponseModel Medals { get; set; } = null!;
    public string ImageUrl { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
