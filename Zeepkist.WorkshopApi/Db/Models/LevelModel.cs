namespace TNRD.Zeepkist.WorkshopApi.Db.Models;

public partial class LevelModel
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int Author { get; set; }

    public int File { get; set; }

    public int Medals { get; set; }

    public string Image { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public decimal WorkshopId { get; set; }

    public virtual AuthorModel AuthorNavigation { get; set; } = null!;

    public virtual FileModel FileNavigation { get; set; } = null!;

    public virtual MedalModel MedalsNavigation { get; set; } = null!;
}
