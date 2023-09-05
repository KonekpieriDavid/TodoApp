namespace RegistrationLogin.Models
{
    public class AuthenticationRequest
    {
        public string? UserName { get; set; }    
        public string? PasswordHash { get; set; }
    }
}
