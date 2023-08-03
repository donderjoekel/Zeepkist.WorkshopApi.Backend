namespace TNRD.Zeepkist.WorkshopApi.Db.Models;

public partial class LevelModel
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int Author { get; set; }

    public int File { get; set; }

    public string Image { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public decimal WorkshopId { get; set; }

    public bool Valid { get; set; }

    public float Validation { get; set; }

    public float Gold { get; set; }

    public float Silver { get; set; }

    public float Bronze { get; set; }

    public virtual AuthorModel AuthorNavigation { get; set; } = null!;

    public virtual FileModel FileNavigation { get; set; } = null!;
}
