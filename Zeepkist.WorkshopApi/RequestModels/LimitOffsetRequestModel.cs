using System.ComponentModel;
using FastEndpoints;

namespace Zeepkist.WorkshopApi.RequestModels;

public class LimitOffsetRequestModel
{
    [QueryParam, DefaultValue(100)] public int Limit { get; set; } = 100;
    [QueryParam, DefaultValue(0)] public int Offset { get; set; } = 0;
}
