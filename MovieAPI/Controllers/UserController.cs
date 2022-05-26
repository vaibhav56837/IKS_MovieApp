using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieApp.Business.Services;
using MovieApp.Data.Repositories;
using MovieApp.Entity;
namespace MovieAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        UserService _userService;
        public UserController(UserService userService)
        {
            _userService = userService;
        }
        [HttpGet("SelectUsers")]
        public IActionResult SelectUsers()
        {
            return Ok(_userService.selectUsers());
        }
        [HttpGet("GetSpecificUsers")]
        public IActionResult GetSpecificUsers(int UserId)
        {
            return Ok(_userService.GetSpecificUsers(UserId));
        }
        [HttpPost("Register")]
        public IActionResult Register(UserModel userModel)
        {
         return Ok(_userService.Register(userModel));
        }
        [HttpPut("UpdateUser")]
        public IActionResult UpdateUser([FromBody] UserModel userModel)
        {
            _userService.UpdateUser(userModel);
            return Ok("User updated successfully!!");
        }
        [HttpDelete("DeleteUser")]
        public IActionResult DeleteUser(int UserId)
        {
            _userService.DeleteUser(UserId);
            return Ok("User Deleted successfully");
        }

        [HttpPost("Login")]
        public IActionResult Login(UserModel userModel)
        {
            return Ok(_userService.Login(userModel));
        }
    }
}
