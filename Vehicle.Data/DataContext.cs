using Rental_Vehicle.Enties;
using Vehicle.Core.Enties;

namespace Rental_Vehicle
{
    public class DataContext
    {
     public  List<User> users {  get; set; }
     public  List<Vehicles> vehicles {  get; set; }
     public  List<Payment> payments {  get; set; }

        public DataContext()
        {
              users = new List<User>
        {
             new User{name="michal",tel="03123456",CodeVehicle=1233},
             new User{name="shira",tel="0344444",CodeVehicle=13233}
        };
            vehicles = new List<Vehicles>{
               new Vehicles { code=1234, type = "Bicycle" },
               new Vehicles {  code=12544, type = "Scooter" }
            };
              payments = new List<Payment>
        {
             new Payment{code=1233,name="michal",price=45},
             new Payment{code=12,name="shira",price=50},

        };

       }
    }
}
