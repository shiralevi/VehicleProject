
using Rental_Vehicle.Enties;
using System;
using System.Collections.Generic;
using Vehicle.Core.Enties;

namespace Vehicle.Core.Services
{
    public interface IVehicleService
    {
        List<Vehicles> Get();
        Vehicles GetVehicle(string type);
        void AddVehicle(Vehicles vehicle);
        bool UpdateVehicle(int codeVehicle, Vehicles vehicle);
        void Delete(int codeVehicle);
    }
}