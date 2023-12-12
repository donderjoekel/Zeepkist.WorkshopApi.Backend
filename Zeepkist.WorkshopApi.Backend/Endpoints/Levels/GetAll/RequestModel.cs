using System.ComponentModel;
using TNRD.Zeepkist.WorkshopApi.Backend.RequestModels;

namespace TNRD.Zeepkist.WorkshopApi.Backend.Endpoints.Levels.GetAll;

public class RequestModel : LimitOffsetRequestModel
{
    [QueryParam] [DefaultValue(false)] public bool IncludeReplaced { get; set; } = false;
    [QueryParam] [DefaultValue(false)] public bool IncludeDeleted { get; set; } = false;
    [QueryParam] [DefaultValue(null)] public string? DateCreated { get; set; } = null;
    [QueryParam] [DefaultValue(null)] public string? DateUpdated { get; set; } = null;
}
