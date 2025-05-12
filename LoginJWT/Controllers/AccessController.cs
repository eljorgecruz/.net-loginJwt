using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LoginJWT.Custom;
using LoginJWT.Models;
using LoginJWT.Models.DTOs;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;

namespace LoginJWT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccessController : ControllerBase
    {
        private readonly LoginDbContext _loginDbContext;
        private readonly Utilities _utilities;
        public AccessController(LoginDbContext loginDbContext, Utilities utilities)
        {
            _loginDbContext = loginDbContext;
            _utilities = utilities;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(UserDTO userObject)
        {
            if (await _loginDbContext.Users.AnyAsync(u => u.Email == userObject.Email))
            {
                return StatusCode(StatusCodes.Status400BadRequest, new { isSuccess = false, message = "Email is already registered" });
            } 

            var UserModel = new User
            {
                Name = userObject.Name,
                Email = userObject.Email,
                Password = _utilities.encryptSHA256(userObject.Password)
            };

            await _loginDbContext.Users.AddAsync(UserModel);
            await _loginDbContext.SaveChangesAsync();
            
            if(UserModel.IdUser != 0)
                return StatusCode(StatusCodes.Status200OK, new {isSuccess = true});
            else
                return StatusCode(StatusCodes.Status200OK, new {isSuccess = false});
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(Login userObject)
        {
            var userFound = await _loginDbContext.Users
                            .Where(u =>
                                u.Email == userObject.email &&
                                u.Password == _utilities.encryptSHA256(userObject.password)
                                ).FirstOrDefaultAsync();

            if (userFound == null)
                return StatusCode(StatusCodes.Status200OK, new { isSuccess = false, token = "" });
            else
                return StatusCode(StatusCodes.Status200OK, new { isSuccess = true, token = _utilities.genarateJWT(userFound) });

        }

    }
}
