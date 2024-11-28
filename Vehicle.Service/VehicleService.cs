using Rental_Vehicle.Enties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicle.Core.Enties;
using Vehicle.Core.Repositories;
using Vehicle.Data.Repositories;

namespace Vehicle.Service
{
    public class VehicleService
    {
        private VehicleReposirory _vehicleRepository;

        public VehicleService(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }
        public List<Vehicles> Get()
        {
            return _vehicleRepository.Get();
        }
        public Vehicles addVehicle(Vehicles vehicles)
        {
            var pays = _vehicleRepository.Get();
            var exist = pays.Contains(payment);
            if (exist)
            {
                return new Payment();
            }
            return _vehicleRepository.Add(payment);
        }
        public bool IsExist(string Vehicles)
        {
            var vehicles = _vehicleRepository.Get();
            var exist = vehicles.Any(vehicles => vehicles.code == vehicles.code);
            if (exist) { return true; }
            return false;
        }

    }
}
