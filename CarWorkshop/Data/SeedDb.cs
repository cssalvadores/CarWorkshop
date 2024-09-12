using System;
using System.Linq;
using System.Threading.Tasks;
using CarWorkshop.Data.Entities;
using CarWorkshop.Helpers;
using Microsoft.AspNetCore.Identity;

namespace CarWorkshop.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;        
        private Random _random;

        public SeedDb(DataContext context,IUserHelper userHelper)
        {
            _context = context;
            _userHelper = userHelper;
            _random = new Random();
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();

            var user = await _userHelper.GetUserByEmailAsync("cssalvador29@gmail.com");

            if (user == null)
            {
                user = new User
                {
                    FirstName = "César",
                    LastName = "Salvador",
                    Email = "cssalvador29@gmail.com",
                    UserName = "cssalvador29@gmail.com",
                    PhoneNumber = "123456789"
                };

                var result = await _userHelper.AddUserAsync(user, "12345");
                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("could not create the user in seeder");
                }
            }

            if (!_context.Vehicles.Any())
            {
                AddVehicle("Mercedes Benz", user);
                AddVehicle("Audi", user);
                AddVehicle("Nissan", user);
                AddVehicle("Toyota", user); 
                AddVehicle("Renault", user);
                await _context.SaveChangesAsync();
            }
        }

        private void AddVehicle(string brand, User user)
        {
            _context.Vehicles.Add(new Vehicle
            {
                Brand = brand,
                Model = "Default",
                LicensePlate = "XX-00-AA",
                Year = DateTime.Now.Year,
                Mileage = _random.Next(5000),
                LastInspectionDate = DateTime.Now.AddMonths(-_random.Next(1, 24)),
                UnderRepair = false,
                User = user
            });
        }
    }
}
