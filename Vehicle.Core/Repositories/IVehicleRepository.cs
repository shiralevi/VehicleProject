using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicle.Core.Enties;

namespace Vehicle.Core.Repositories
{
    public interface IVehicleRepository
    {
        public List<Vehicles> Get();
        public string Get(int codeVehicle);
        public void Post(Vehicles vehicle);
        public void Put(int codeVeicle, Vehicles vehicle);
        public void Delete(int codeVehicle);


    }
}
