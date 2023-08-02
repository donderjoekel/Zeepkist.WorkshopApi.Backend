namespace TNRD.Zeepkist.WorkshopApi.Db.Models;

public partial class FileModel
{
    public int Id { get; set; }

    public string Hash { get; set; } = null!;

    public string Url { get; set; } = null!;

    public string Author { get; set; } = null!;

    public string Uid { get; set; } = null!;

    public virtual ICollection<LevelModel> Levels { get; set; } = new List<LevelModel>();
}
