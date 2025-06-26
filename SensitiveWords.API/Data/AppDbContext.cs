using Microsoft.EntityFrameworkCore;
using SensitiveWords.API.Models;

namespace SensitiveWords.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<SensitiveWord> SensitiveWords { get; set; }
    }
}
