using Microsoft.EntityFrameworkCore;

namespace Groupweb.DBContext
{
    public class tennisDBContext : DbContext
    {
        public tennisDBContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Admins> SalesProducts { get; set; }
    }
}
