using System.ComponentModel;

namespace TNRD.Zeepkist.WorkshopApi.Backend.Endpoints.Levels.GetByHashes;

public class RequestModel
{
    public string Hashes { get; set; }
    [QueryParam] [DefaultValue(false)] public bool IncludeReplaced { get; set; } = false;
    [QueryParam] [DefaultValue(false)] public bool IncludeDeleted { get; set; } = false;
}
