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

    public virtual DbSet<AuthorModel> Authors { get; set; }

    public virtual DbSet<FileModel> Files { get; set; }

    public virtual DbSet<LevelModel> Levels { get; set; }

    public virtual DbSet<MedalModel> Medals { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AuthorModel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("authors_pkey");

            entity.ToTable("authors");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.DisplayName).HasColumnName("display_name");
            entity.Property(e => e.SteamId).HasColumnName("steam_id");
        });

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
            entity.Property(e => e.Author).HasColumnName("author");
            entity.Property(e => e.CreatedAt).HasColumnName("created_at");
            entity.Property(e => e.File).HasColumnName("file");
            entity.Property(e => e.Image).HasColumnName("image");
            entity.Property(e => e.Medals).HasColumnName("medals");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
            entity.Property(e => e.WorkshopId).HasColumnName("workshop_id");

            entity.HasOne(d => d.AuthorNavigation).WithMany(p => p.Levels)
                .HasForeignKey(d => d.Author)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("levels_author_fkey");

            entity.HasOne(d => d.FileNavigation).WithMany(p => p.Levels)
                .HasForeignKey(d => d.File)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("levels_file_fkey");

            entity.HasOne(d => d.MedalsNavigation).WithMany(p => p.Levels)
                .HasForeignKey(d => d.Medals)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("levels_medals_fkey");
        });

        modelBuilder.Entity<MedalModel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("medals_pkey");

            entity.ToTable("medals");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Bronze).HasColumnName("bronze");
            entity.Property(e => e.Gold).HasColumnName("gold");
            entity.Property(e => e.Silver).HasColumnName("silver");
            entity.Property(e => e.Validation).HasColumnName("validation");
            entity.Property(e => e.IsValid).HasColumnName("valid");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
