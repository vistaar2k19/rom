using AuthenticationDbContext.Data;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Data
{
    public class JWTAuthenticationManager : IJWTAuthenticationManager
    {
        //private readonly AuthenticationContext _context;
        private readonly string tokenKey;
        //private ILoginRepo _loginRepo= new LoginRepo();

        public JWTAuthenticationManager(string tokenKey)
        {
            this.tokenKey = tokenKey;
        }

        public string Authenticate(string userId, string userPassword)
        {
          //  var temp = _loginRepo.LoginExists(userId, userPassword);
            //if (!_loginRepo.LoginExists( userId,  userPassword))
            //{
            //    return null;
            //}

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(tokenKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, userId)
                    
                }),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        } 

    }
}
