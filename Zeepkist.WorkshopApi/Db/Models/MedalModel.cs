namespace TNRD.Zeepkist.WorkshopApi.Db.Models;

public partial class MedalModel
{
    public int Id { get; set; }
    
    public bool IsValid { get; set; }

    public float Validation { get; set; }

    public float Gold { get; set; }

    public float Silver { get; set; }

    public float Bronze { get; set; }

    public virtual ICollection<LevelModel> Levels { get; set; } = new List<LevelModel>();
}
