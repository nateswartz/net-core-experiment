using Microsoft.EntityFrameworkCore;

namespace NETCoreExperimentalWebApp.Models
{
    public class NETCoreExperimentalWebAppContext : DbContext
    {
        public NETCoreExperimentalWebAppContext (DbContextOptions<NETCoreExperimentalWebAppContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Book { get; set; }
    }
}
