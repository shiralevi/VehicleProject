using Rental_Vehicle.Enties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicle.Core.Services
{
    public interface IUserService
    {
        public List<User> Get();
        public User GetUser(String tel);
        public bool AddUser(User user);
        public bool UpdateUser(String tel, User user);
        public bool DeleteUser(string tel);
    }
}
