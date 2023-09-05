namespace RegistrationLogin.Models
{
    [Serializable]
    public class JwtAuthResponse
    {
        public string? Token { get; set; }   
        public string? UserName { get; set; }
         public int Expires_in { get; set; }    

    }
}
