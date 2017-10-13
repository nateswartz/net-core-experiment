using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NETCoreExperimentalWebApp.Models;

namespace NETCoreExperimentalWebApp.Data
{
    public class WebAppDbContext : IdentityDbContext<ApplicationUser>
    {
        public WebAppDbContext (DbContextOptions<WebAppDbContext> options)
            : base(options)
        {
        }

        public DbSet<BookModel> Book { get; set; }
    }
}
