namespace Zeepkist.WorkshopApi.Endpoints.Levels.Exists;

public class RequestModel
{
    [QueryParam] public string Name { get; set; } = null!;
    [QueryParam] public int Author { get; set; }
    [QueryParam] public int File { get; set; }
    [QueryParam] public int Medals { get; set; }
    [QueryParam] public string WorkshopId { get; set; } = null!;
}
