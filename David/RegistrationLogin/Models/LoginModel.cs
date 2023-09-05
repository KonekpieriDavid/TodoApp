using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace RegistrationLogin.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "User Name is required")]
        public string? Username { get; set; }

       [Required(ErrorMessage = "Password is required")]
        public string? PasswordHash { get; set; }
    }
}
