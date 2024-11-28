using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Vehicle.Core.Enties;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Rental_Vehicle.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {


        private readonly DataContext context;
        public VehicleController(DataContext data)
        {
            context = data;           
        }

        // GET: api/<VaehicleController>
        [HttpGet]
        public IEnumerable<Vehicles> Get()
        {
            return context.vehicles;
        }

        // GET api/<VaehicleController>/5
        [HttpGet("{codeVehicle}")]
        public string Get(int codeVehicle)
        {
            var index = context.vehicles.FindIndex(e => e.code == codeVehicle);
            if (index != -1)
                return context.vehicles[index].type;

            return null;
        }

        // POST api/<VaehicleController>
        [HttpPost]
        public void Post([FromBody] Vehicles vehicle)
        {
            context.vehicles.Add(vehicle);

        }

        // PUT api/<VaehicleController>/5
        [HttpPut("{id}")]
        public void Put(int codeVeicle, [FromBody] Vehicles vehicle)
        {
            var index = context.vehicles.FindIndex(e => e.code == codeVeicle);
            if (index != -1) { }
             context.vehicles[index].type = vehicle.type;
            context.vehicles[index].code = vehicle.code;
        }

       //מחיקה לפי קוד
        [HttpDelete("{id}")]
        public void Delete(int codeVehicle)
        {
            var index = context.vehicles.FindIndex(e => e.code==codeVehicle);
            if (index != -1)
                context.vehicles.Remove(context.vehicles[index]);
            else
                Console.WriteLine("Not sucssed");

        }
    }
}
