using Rental_Vehicle.Enties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicle.Core.Repositories
{
    public interface IUserRepository
    {
        public List<User> Get();

        public User GetUser(String tel);
        public void Put(String tel, User value);

        public User Post(User value);
        

        public void Delete(string tel);

    }
}
