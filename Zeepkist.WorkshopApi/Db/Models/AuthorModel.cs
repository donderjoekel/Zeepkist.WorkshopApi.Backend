namespace TNRD.Zeepkist.WorkshopApi.Db.Models;

public partial class AuthorModel
{
    public int Id { get; set; }

    public decimal SteamId { get; set; }

    public string DisplayName { get; set; } = null!;

    public virtual ICollection<LevelModel> Levels { get; set; } = new List<LevelModel>();
}
