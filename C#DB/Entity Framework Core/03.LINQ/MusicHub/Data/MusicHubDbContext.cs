namespace MusicHub.Data
{
    using Microsoft.EntityFrameworkCore;
    using MusicHub.Data.Models;

    public class MusicHubDbContext : DbContext
    {
        public MusicHubDbContext()
        {
        }

        public MusicHubDbContext(DbContextOptions options)
            : base(options)
        {
        }
        DbSet<Album> Albums { get; set; } = null!;
        DbSet<Performer> Performsers { get; set; } = null!;
        DbSet<Producer> Producers { get; set; } = null!;
        DbSet<Song> Songs { get; set; } = null!;
        DbSet<SongPerformer> SongPerformers { get; set; } = null!;
        DbSet<Writer> Writers { get; set; } = null!;


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Song>(e =>
            {
                e
                    .Property(s => s.CreatedOn)
                    .HasColumnType("date");
            });

            builder.Entity<Album>(a =>
            {
                a
                    .Property(a => a.ReleaseDate)
                    .HasColumnType("date");
            });
            builder.Entity<SongPerformer>(entity =>
            {
                entity.HasKey(sp => new { sp.SongId , sp.PerformerId });
            });
        }
    }
}
