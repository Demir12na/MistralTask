using Microsoft.EntityFrameworkCore;
using MistralTask.MistralTaskDatabaseEntities;

namespace MistralTask.MistralTaskDatabase
{
    public class MistralTaskDbContext : DbContext
    {
        public MistralTaskDbContext(DbContextOptions<MistralTaskDbContext> options)
            : base(options)
        {
        }
        public DbSet<Movies> Movies { get; set; }
        public DbSet<TvShows> TvShows { get; set; }
        public DbSet<Ratings> Ratings { get; set; }

    }
}
