using System.ComponentModel;

namespace TNRD.Zeepkist.WorkshopApi.Backend.Endpoints.Levels.GetByWorkshopIds;

public class RequestModel
{
    public string Ids { get; set; } = null!;
    [QueryParam] [DefaultValue(false)] public bool IncludeReplaced { get; set; } = false;
    [QueryParam] [DefaultValue(false)] public bool IncludeDeleted { get; set; } = false;
}
