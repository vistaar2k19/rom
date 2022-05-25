using Authentication.Models;
using AuthenticationDbContext.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Authentication.Data
{
    public class LoginRepo : ILoginRepo
    {
        private readonly AuthenticationContext _context;

        public LoginRepo(AuthenticationContext context)
        {
            _context = context;
        }
        public bool LoginExists(string userId, string userPassword)
        {
            if (userId == "ADMIN" && userPassword == "ADMIN")
            {
                return true;
            }
            else return false;

            //return _context.UserLogin.Any(u => u.UserId == userId && u.UserPassword == userPassword);
        }

        
    }
}
