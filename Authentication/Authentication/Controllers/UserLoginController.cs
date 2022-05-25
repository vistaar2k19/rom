using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Authentication.Models;
using AuthenticationDbContext.Data;
using Authentication.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Logging;

namespace Authentication.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserLoginController : ControllerBase
    {
        //private readonly AuthenticationContext _context;
        private readonly IJWTAuthenticationManager jWTAuthenticationManager;
        //public IConfiguration _configuration;
        private readonly ILoginRepo _loginRepo;
        //private readonly Logger _logger;

        public UserLoginController(  ILoginRepo loginRepo, IJWTAuthenticationManager jWTAuthenticationManager)
        {
            this.jWTAuthenticationManager = jWTAuthenticationManager;
            this._loginRepo = loginRepo;
            //this._context = context;

        }


        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] UserLogin userLogin)
        {
            try
            {
                if (userLogin.UserId == "" || userLogin.UserPassword == "")
                {
                    return StatusCode(400, new { token = "empty", message = "invalid" });
                }

                if (!_loginRepo.LoginExists(userLogin.UserId, userLogin.UserPassword))
                {
                    return StatusCode(401, new { token = "empty", message = "invalid" });
                }
                var token = jWTAuthenticationManager.Authenticate(userLogin.UserId, userLogin.UserPassword);

                if (token == null)
                    return Ok(new { token = "empty", message = "invalid" });
                return Ok(new { token = token, message = "valid" });
                //return Ok(_loginRepo.LoginExists(userLogin.UserId, userLogin.UserPassword));
                ////return Ok(_context.UserLogin.FirstOrDefault());
                //return Ok(Authenticate(userLogin.UserId, userLogin.UserPassword));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return StatusCode(500, new { message = "Error occured" });

            }
        }

    }
}
