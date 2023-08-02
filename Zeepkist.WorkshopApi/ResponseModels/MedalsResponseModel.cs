namespace Zeepkist.WorkshopApi.ResponseModels;

public class MedalsResponseModel
{
    public int Id { get; set; }
    public bool IsValid { get; set; }
    public float Validation { get; set; }
    public float Gold { get; set; }
    public float Silver { get; set; }
    public float Bronze { get; set; }
}
