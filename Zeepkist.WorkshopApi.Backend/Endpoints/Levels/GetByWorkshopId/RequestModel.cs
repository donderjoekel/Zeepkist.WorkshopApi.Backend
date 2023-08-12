using System.ComponentModel;

namespace TNRD.Zeepkist.WorkshopApi.Backend.Endpoints.Levels.GetByWorkshopId;

public class RequestModel
{
    public string Id { get; set; } = null!;
    [QueryParam, DefaultValue(false)] public bool IncludeReplaced { get; set; } = false;
}
