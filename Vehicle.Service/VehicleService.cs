
using Rental_Vehicle.Enties;
using System;
using System.Collections.Generic;
using System.Linq;
using Vehicle.Core.Enties;
using Vehicle.Core.Repositories;
using Vehicle.Core.Services;

namespace Vehicles.Service
{
    public class VehicleService : IVehicleService
    {
        private IVehicleRepository _vehicleRepository;

        public VehicleService(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        // מחזיר את כל הרכבים
        public List<Vehicles> Get()
        {
            return _vehicleRepository.Get();
        }

        // מחזיר רכב לפי סוג
        public Vehicles GetVehicle(string type)
        {
            return _vehicleRepository.GetVehicle(type);
        }

        // הוספת רכב
        public void AddVehicle(Vehicles vehicle)
        {
            var existingVehicle = _vehicleRepository.Get().FirstOrDefault(v => v.code == vehicle.code);
            if (existingVehicle != null)
            {
                // רכב עם אותו קוד כבר קיים, לא ניתן להוסיף אותו
                return;
            }
            _vehicleRepository.Post(vehicle);  // מוסיף את הרכב למאגר
            // אין צורך להחזיר ערך בשיטה זו
        }

        // עדכון רכב
        public bool UpdateVehicle(int codeVehicle, Vehicles vehicle)
        {
            if (!IsExist(codeVehicle))
                return false;  // אם הרכב לא קיים, לא ניתן לעדכן

            _vehicleRepository.Put(codeVehicle, vehicle);  // מעדכן את הרכב במאגר
            return true;  // עדכון הצליח
        }

        // בדיקת קיום רכב
        public bool IsExist(int code)
        {
            var vehicle = _vehicleRepository.Get().FirstOrDefault(v => v.code == code);
            return vehicle != null;  // מחזיר true אם הרכב קיים, אחרת false
        }

        // מחיקת רכב
        public void Delete(int codeVehicle)
        {
            if (IsExist(codeVehicle))
            {
                _vehicleRepository.Delete(codeVehicle); // הנחתי שיש שיטה כזו במחלקת המאגר
            }
            else
            {
                throw new KeyNotFoundException("Vehicle not found.");
            }
        }
    }
}
