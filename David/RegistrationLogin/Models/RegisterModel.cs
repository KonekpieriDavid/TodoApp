using System.ComponentModel.DataAnnotations;

namespace RegistrationLogin.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage  ="user name is Required")]
        public string? UserName { get; set; }
        [Required(ErrorMessage =  "password is Required")]
        public string? PasswordHash { get; set; }
    }
}
