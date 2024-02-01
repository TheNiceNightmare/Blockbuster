using Microsoft.EntityFrameworkCore;
using Blockbuster.Models;

namespace Blockbuster.Data
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {
        }

        public DbSet<Movies> Movies { get; set; }

    }
}
