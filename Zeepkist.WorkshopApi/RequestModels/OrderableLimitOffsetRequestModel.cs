using System.ComponentModel;

namespace Zeepkist.WorkshopApi.RequestModels;

public class OrderableLimitOffsetRequestModel : LimitOffsetRequestModel
{
    [QueryParam, DefaultValue("")] public string? OrderBy { get; set; } = string.Empty;
    [QueryParam, DefaultValue(false)] public bool? Descending { get; set; } = false;
}
