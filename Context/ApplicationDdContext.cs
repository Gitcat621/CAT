using Microsoft.EntityFrameworkCore;
using proyecto24BM.Models;

namespace proyecto24BM.Context
{
    public class ApplicationDdContext : DbContext
    {
        public ApplicationDdContext(DbContextOptions<ApplicationDdContext> options) : base(options) { }
        public DbSet<usuario> usuarios { get; set; }
        public DbSet<roles> Roles { get; set; }
        public DbSet<Articulos> articulos { get; set; }
    }
}
