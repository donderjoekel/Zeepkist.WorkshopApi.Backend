using System.ComponentModel;

namespace TNRD.Zeepkist.WorkshopApi.Backend.RequestModels;

public class GetRandomRequestModel
{
    [QueryParam] [DefaultValue(1)] public int Amount { get; set; }
}
