using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MovieApp.Data.DataConnection;
using MovieApp.Entity;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MovieAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly MovieDBContext _context;

        public TokenController(IConfiguration config, MovieDBContext context)
        {
            _configuration = config;
            _context = context;
        }

        private async Task<UserModel> GetUser(string email, string password)
        {
            UserModel userModel = null;
            var result = _context.userModel.Where(u => u.Email == email && u.Password == password);

            foreach (var item in result)
            {
                userModel = new UserModel();
                userModel.UserId = item.UserId;
                userModel.Firstname = item.Firstname;
                userModel.Lastname = item.Lastname;
                userModel.Email = item.Email;
                userModel.Mobile = item.Mobile;

            }
            return userModel;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Post(UserModel userModel)
        {

            if (userModel != null && userModel.Email != null && userModel.Password != null)
            {
                var user = await GetUser(userModel.Email, userModel.Password);

                if (user != null)
                {
                    //create claims details based on the user information
                    var claims = new[] {
                    new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                    new Claim("UserId", user.UserId.ToString()),
                    new Claim("FirstName", user.Firstname),
                    new Claim("LastName", user.Lastname),
                    new Claim("Email", user.Email),
                   };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                    var token = new JwtSecurityToken(_configuration["Jwt:Issuer"], _configuration["Jwt:Audience"], claims, expires: DateTime.UtcNow.AddDays(1), signingCredentials: signIn);

                    return Ok(new JwtSecurityTokenHandler().WriteToken(token));
                }
                else
                {
                    return BadRequest("Invalid credentials");
                }
            }
            else
            {
                return BadRequest();
            }
        }
 
    }
}
