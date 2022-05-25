using Authentication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Authentication.Data
{
    public interface ILoginRepo
    {
        public bool LoginExists(string userId, string userPassword);

    }
}
