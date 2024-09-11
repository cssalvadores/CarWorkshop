using CarWorkshop.Data.Entities;

namespace CarWorkshop.Data
{
    public class VehicleRepository : GenericRepository<Vehicle>, IVehicleRepository
    {
        public VehicleRepository(DataContext context) : base(context)
        {            
        }
    }
}
