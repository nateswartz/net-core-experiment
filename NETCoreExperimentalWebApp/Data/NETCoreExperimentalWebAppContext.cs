using Microsoft.EntityFrameworkCore;
using NETCoreExperimentalWebApp.Models;

namespace NETCoreExperimentalWebApp.Data
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
