using Car_Dealership.Model;
using Microsoft.EntityFrameworkCore;

namespace Car_Dealership.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {

        }
            public DbSet<Car> Cars { get; set; }
            public DbSet<Client> Clients { get; set; }
        
    }
}
