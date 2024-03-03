namespace TNRD.Zeepkist.WorkshopApi.Backend.Endpoints.Levels.Put.Updated;

public class RequestModel
{
    [QueryParam] public int Id { get; set; }
    [QueryParam] public long Ticks { get; set; }
}
