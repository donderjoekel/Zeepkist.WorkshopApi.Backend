namespace TNRD.Zeepkist.WorkshopApi.Endpoints.Levels.Exists;

public class RequestModel
{
    [QueryParam] public string Name { get; set; } = null!;
    [QueryParam] public int Author { get; set; }
    [QueryParam] public int File { get; set; }
    [QueryParam] public bool Valid { get; set; }
    [QueryParam] public float Validation { get; set; }
    [QueryParam] public float Gold { get; set; }
    [QueryParam] public float Silver { get; set; }
    [QueryParam] public float Bronze { get; set; }
    [QueryParam] public string WorkshopId { get; set; } = null!;
}
