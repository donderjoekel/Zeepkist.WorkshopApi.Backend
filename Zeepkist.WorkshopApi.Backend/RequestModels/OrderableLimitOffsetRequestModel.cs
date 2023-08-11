using System.ComponentModel;

namespace TNRD.Zeepkist.WorkshopApi.Backend.RequestModels;

public class OrderableLimitOffsetRequestModel : LimitOffsetRequestModel
{
    [QueryParam, DefaultValue("")] public string? OrderBy { get; set; } = string.Empty;
    [QueryParam, DefaultValue(false)] public bool? Descending { get; set; } = false;
}
