namespace TNRD.Zeepkist.WorkshopApi.Backend.Endpoints.Levels.Put.Replace;

public class RequestModel
{
    [QueryParam] public int Id { get; set; }
    [QueryParam] public int Replacement { get; set; }
}
