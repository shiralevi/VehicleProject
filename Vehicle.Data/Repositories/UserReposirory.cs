using Rental_Vehicle;
using Rental_Vehicle.Enties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicle.Data.Repositories
{
    public class UserReposirory : IUserService
    {
        private DataContext _context;

        public UserReposirory(DataContext context)
        {
            _context = context;
        }
        public List<User> Get()
        {
            return _context.users;
        }

   
        public User GetUser(String tel)
        {
            var index = _context.users.FindIndex(e => e.tel.Equals(tel));
            if (index != -1)
                return _context.users[index];
            return null;

        }

        
        public void Put(String tel,  User value)
        {
            var index = _context.users.FindIndex(e => e.tel.Equals(tel));
            if (index != -1)
            {
                _context.users[index].name = value.name;
                _context.users[index].tel = value.tel;
            }
            Console.WriteLine("Not sucssed");

        }


        public User Post( User value)
        {
            _context.users.Add(value);
            return value;

        }


        public void Delete(string tel)
        {
            var index = _context.users.FindIndex(e => e.tel.Equals(tel));
            if (index != -1)
                _context.users.Remove(_context.users[index]);
            else
                Console.WriteLine("Not sucssed");
        }
    }
}

