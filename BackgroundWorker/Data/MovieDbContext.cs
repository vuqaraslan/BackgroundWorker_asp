using BackgroundWorker.Entities;
using Microsoft.EntityFrameworkCore;

namespace BackgroundWorker.Data
{
    public class MovieDbContext : DbContext
    {
        public MovieDbContext(DbContextOptions<MovieDbContext> options)
            : base(options) { }

        public DbSet<Movie> Movies{ get; set; }
    }
}
