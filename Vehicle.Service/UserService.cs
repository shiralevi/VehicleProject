using Rental_Vehicle.Enties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicle.Core.Repositories;
using Vehicle.Core.Services;
using Vehicle.Data.Repositories;
namespace Vehicle.Service
{
    public class UserService: IUserService
    {
     private  IUserRepository _userRepository;
        
     public UserService (IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public List<User> Get()
        {
            return _userRepository.Get();
        }
        public User GetUser(String tel) {
            return _userRepository.GetUser(tel);
        }
        public bool AddUser(User user) 

        {
          if (IsExist(user.tel))
            {
                return true;
            }
            return false;

        }
        public bool UpdateUser(String tel, User user)
        {
          if (!IsExist(tel)) 
                return false;
           return true;
        }
        public bool DeleteUser(string tel)
        {
            if (IsExist(tel))
            {
                return false;
            }
            return true;
        }

        public bool IsExist(string tel)
        {
            var use = _userRepository.Get();
            var exist = use.Any(users => users.tel == tel);
            if (exist) 
              return true; 
            return false;
        }
        
    }
}
