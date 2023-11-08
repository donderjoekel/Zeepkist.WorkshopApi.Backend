using System.ComponentModel;

namespace TNRD.Zeepkist.WorkshopApi.Backend.Endpoints.Levels.GetByUid;

public class RequestModel
{
    public string Uid { get; set; } = null!;
    [QueryParam] [DefaultValue(false)] public bool IncludeReplaced { get; set; } = false;
    [QueryParam] [DefaultValue(false)] public bool IncludeDeleted { get; set; } = false;
}
