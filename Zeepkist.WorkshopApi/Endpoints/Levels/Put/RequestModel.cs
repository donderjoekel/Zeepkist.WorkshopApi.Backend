namespace TNRD.Zeepkist.WorkshopApi.Endpoints.Levels.Put;

public class RequestModel
{
    [QueryParam] public int Id { get; set; }
    [QueryParam] public int Replacement { get; set; }
}
