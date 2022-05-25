using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Authentication.Models
{
    public class UserLogin
    {
        [Key]
        [Required(ErrorMessage = "Please provide User name")]
        public string UserId { get; set; }

        [Required(ErrorMessage = "Please provide Password")]
        public string UserPassword { get; set; }
    }
}
