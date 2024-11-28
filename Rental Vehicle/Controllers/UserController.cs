using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Rental_Vehicle.Enties;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Rental_Vehicle.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DataContext context;
        public UserController(DataContext data)
        {
            context = data;
        }


        [HttpGet]
        public IEnumerable<User> Get()
        {
            return context.users;
        }

        //מציאת משתמש
        [HttpGet("{tel}")]
        public User GetUser(String tel)
        {
            var index = context.users.FindIndex(e => e.tel.Equals(tel));
            if (index != -1)
                return context.users[index];
            return null;

        }

        //עדכון משתמש
        [HttpPut("{tel}")]
        public void Put(String tel, [FromBody] User value)
        {
            var index = context.users.FindIndex(e => e.tel.Equals(tel));
            if (index != -1)
            {
                context.users[index].name = value.name;
                context.users[index].tel = value.tel;
            }
            Console.WriteLine("Not sucssed");

        }


        //הוספת משתמש
        [HttpPost]
        public ActionResult Post([FromBody] User value)
        {
            context.users.Add(value);
            return value;

        }

        // מחיקת משתמש
        [HttpDelete("{tel}")]
        public void Delete(string tel)
        {
            var index = context.users.FindIndex(e => e.tel.Equals(tel));
            if (index != -1)
                context.users.Remove(context.users[index]);
            else
                Console.WriteLine("Not sucssed");

        }
    }
}
