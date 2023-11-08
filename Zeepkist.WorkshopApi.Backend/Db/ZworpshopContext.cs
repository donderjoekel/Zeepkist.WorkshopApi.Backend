using Microsoft.EntityFrameworkCore;
using TNRD.Zeepkist.WorkshopApi.Backend.Db.Models;

namespace TNRD.Zeepkist.WorkshopApi.Backend.Db;

public partial class ZworpshopContext : DbContext
{
    public ZworpshopContext()
    {
    }

    public ZworpshopContext(DbContextOptions<ZworpshopContext> options)
        : base(options)
    {
    }

    public virtual DbSet<LevelModel> Levels { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<LevelModel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("levels_pkey");

            entity.ToTable("levels");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.AuthorId).HasColumnName("author_id");
            entity.Property(e => e.Bronze).HasColumnName("bronze");
            entity.Property(e => e.CreatedAt).HasColumnName("created_at");
            entity.Property(e => e.Deleted).HasColumnName("deleted");
            entity.Property(e => e.FileAuthor).HasColumnName("file_author");
            entity.Property(e => e.FileHash).HasColumnName("file_hash");
            entity.Property(e => e.FileUid).HasColumnName("file_uid");
            entity.Property(e => e.FileUrl).HasColumnName("file_url");
            entity.Property(e => e.Gold).HasColumnName("gold");
            entity.Property(e => e.ImageUrl).HasColumnName("image_url");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.ReplacedBy).HasColumnName("replaced_by");
            entity.Property(e => e.Silver).HasColumnName("silver");
            entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
            entity.Property(e => e.Valid).HasColumnName("valid");
            entity.Property(e => e.Validation).HasColumnName("validation");
            entity.Property(e => e.WorkshopId).HasColumnName("workshop_id");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
