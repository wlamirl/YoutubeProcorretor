using Microsoft.EntityFrameworkCore;
using YoutubeProcorretor.Models;

namespace YoutubeProcorretor.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<VideoModel> Videos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VideoModel>().HasData(
                new VideoModel
                {
                    Id = 1,
                    Title = "Procorretor - Treinamento 1",
                    Thumbnail = "/fotos/blazorCrud.png",
                    Description = "Vídeo de Treinamento 1",
                    Tag = "Treinamento 1",
                    CategoryId = "22",
                    // Tags = new[] { "Treinamento 1", "Treinamento 2"},
                    UrlVideo = "https://www.youtube.com/watch?v=fwKfPCuiTWQ&t=1s"
                    // Name = "Blazor - Crud com Fluent UI",
                    // Foto = "/fotos/blazorCrud.png",
                    // Path = "/fotos",
                    // Type = "png"
                }
            );
        }
    }
}