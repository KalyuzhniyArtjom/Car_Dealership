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
            public DbSet<BrandCar> BrandCars { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<BrandCar>().HasData(
                new BrandCar { Id = 1, Name = "BMW" },
                new BrandCar { Id = 1, Name = "Mercedes" },
                new BrandCar { Id = 1, Name = "Audi" }
                );
        }
            

    }
}
