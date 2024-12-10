using Microsoft.AspNetCore.Mvc;
using Rental_Vehicle.Enties;
using Vehicle.Core.Services;

namespace Rental_Vehicle.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _userService.Get();
        }

        // מציאת משתמש
        [HttpGet("{tel}")]
        public ActionResult<User> GetUser(string tel)
        {
            User user = _userService.GetUser(tel);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        // עדכון משתמש
        [HttpPut("{tel}")]
        public ActionResult UpdateUser(string tel, [FromBody] User value)
        {
            try
            {
                _userService.UpdateUser(tel, value);
                return NoContent(); // מחזיר 204 כאשר העדכון הצליח
            }
            catch (Exception ex)
            {
                return BadRequest($"Error updating user: {ex.Message}");
            }
        }

        // הוספת משתמש
        [HttpPost]
        public ActionResult<User> AddUser([FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest("User cannot be null");
            }

            try
            {
                var result = _userService.AddUser(user); // נניח שיש שיטה להוסיף משתמש
                return CreatedAtAction(nameof(GetUser), new { tel = result.Tel }, result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error adding user: {ex.Message}");
            }
        }

        // מחיקת משתמש
        [HttpDelete("{tel}")]
        public ActionResult DeleteUser(string tel)
        {
            var user = _userService.GetUser(tel);
            if (user == null)
            {
                return NotFound();
            }

            _userService.DeleteUser(tel);
            return NoContent();
        }
    }
}
