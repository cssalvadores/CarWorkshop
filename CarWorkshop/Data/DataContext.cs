using CarWorkshop.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarWorkshop.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {                       
        }
    }
}
