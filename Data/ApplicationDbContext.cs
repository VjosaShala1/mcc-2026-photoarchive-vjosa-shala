using Microsoft.EntityFrameworkCore;
using PhotoArchive.API.Models;

namespace PhotoArchive.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Photo> Photos { get; set; }
    }
}