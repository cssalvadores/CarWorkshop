using System;
using System.Linq;
using System.Threading.Tasks;
using CarWorkshop.Data.Entities;

namespace CarWorkshop.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;
        private Random _random;

        public SeedDb(DataContext context)
        {
            _context = context;
            _random = new Random();
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();

            if (!_context.Vehicles.Any())
            {
                AddVehicle("Mercedes Benz");
                AddVehicle("Audi");
                AddVehicle("Nissan");
                AddVehicle("Toyota"); 
                AddVehicle("Renault");
                await _context.SaveChangesAsync();
            }
        }

        private void AddVehicle(string brand)
        {
            _context.Vehicles.Add(new Vehicle
            {
                Brand = brand,
                Model = "Default",
                LicensePlate = "XX-00-AA",
                Year = DateTime.Now.Year,
                Mileage = _random.Next(5000),
                LastInspectionDate = DateTime.Now.AddMonths(-_random.Next(1, 24)),
                UnderRepair = false
            });
        }
    }
}
