namespace TNRD.Zeepkist.WorkshopApi.Endpoints.Files.Post;

public class RequestModel
{
    public string Hash { get; set; } = null!;
    public byte[] Data { get; set; } = null!;
    public string Uid { get; set; } = null!;
    public string Author { get; set; } = null!;
    public decimal ModioId { get; set; }
}
