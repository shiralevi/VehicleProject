using Rental_Vehicle.Enties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicle.Core.Enties;

namespace Vehicle.Core.Services
{
    public interface IVehicleService
    {
        public List<Vehicles> Get();
        public void Post(Vehicles vehicle);
        public void Put(int codeVeicle,  Vehicles vehicle);
        public void Delete(int codeVehicle);
    }
}
