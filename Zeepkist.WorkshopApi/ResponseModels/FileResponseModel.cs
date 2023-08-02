namespace TNRD.Zeepkist.WorkshopApi.ResponseModels;

public class FileResponseModel
{
    public int Id { get; set; }

    public string Hash { get; set; } = null!;

    public string Url { get; set; } = null!;

    public string Author { get; set; } = null!;

    public string Uid { get; set; } = null!;
}
