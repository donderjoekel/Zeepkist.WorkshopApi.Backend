using Microsoft.EntityFrameworkCore;
using TNRD.Zeepkist.WorkshopApi.Db.Models;

namespace TNRD.Zeepkist.WorkshopApi.Db;

public partial class ZworpshopContext : DbContext
{
    public ZworpshopContext()
    {
    }

    public ZworpshopContext(DbContextOptions<ZworpshopContext> options)
        : base(options)
    {
    }

    public virtual DbSet<FileModel> Files { get; set; }

    public virtual DbSet<LevelModel> Levels { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<FileModel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("files_pkey");

            entity.ToTable("files");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Author).HasColumnName("author");
            entity.Property(e => e.Hash).HasColumnName("hash");
            entity.Property(e => e.Uid).HasColumnName("uid");
            entity.Property(e => e.Url).HasColumnName("url");
        });

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
            entity.Property(e => e.File).HasColumnName("file");
            entity.Property(e => e.Gold).HasColumnName("gold");
            entity.Property(e => e.Image).HasColumnName("image");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Silver).HasColumnName("silver");
            entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
            entity.Property(e => e.Valid).HasColumnName("valid");
            entity.Property(e => e.Validation).HasColumnName("validation");
            entity.Property(e => e.WorkshopId).HasColumnName("workshop_id");

            entity.HasOne(d => d.FileNavigation).WithMany(p => p.Levels)
                .HasForeignKey(d => d.File)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("levels_file_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
