namespace TNRD.Zeepkist.WorkshopApi.Db.Models;

public partial class LevelModel
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string ImageUrl { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public decimal WorkshopId { get; set; }

    public bool Valid { get; set; }

    public float Validation { get; set; }

    public float Gold { get; set; }

    public float Silver { get; set; }

    public float Bronze { get; set; }

    public decimal AuthorId { get; set; }

    public decimal ModioId { get; set; }

    public string FileHash { get; set; } = null!;

    public string FileUrl { get; set; } = null!;

    public string FileAuthor { get; set; } = null!;

    public string FileUid { get; set; } = null!;
}
