using Rental_Vehicle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicle.Core.Enties;
using Vehicle.Core.Repositories;
using Vehicle.Core.Services;

namespace Vehicle.Data.Repositories
{
    public class VehicleRepository : IVehicleRepository
    {
        private DataContext _context;

        public VehicleRepository(DataContext context)
        {
            _context = context;
        }

        public List<Vehicles> Get()
        {
            return _context.vehicles;
        }


        public string Get(int codeVehicle)
        {
            var index = _context.vehicles.FindIndex(e => e.code == codeVehicle);
            if (index != -1)
                return _context.vehicles[index].type;

            return null;
        }


        public void Post(Vehicles vehicle)
        {
            _context.vehicles.Add(vehicle);

        }

        public void Put(int codeVeicle, Vehicles vehicle)
        {
            var index = _context.vehicles.FindIndex(e => e.code == codeVeicle);
            if (index != -1) { }
            _context.vehicles[index].type = vehicle.type;
            _context.vehicles[index].code = vehicle.code;
        }


        public void Delete(int codeVehicle)
        {
            var index = _context.vehicles.FindIndex(e => e.code == codeVehicle);
            if (index != -1)
                _context.vehicles.Remove(_context.vehicles[index]);
            else
                Console.WriteLine("Not sucssed");

        }


    }
}
