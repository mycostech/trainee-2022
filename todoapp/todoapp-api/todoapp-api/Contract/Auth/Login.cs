using System.ComponentModel.DataAnnotations;
namespace todoapp_api.Contract.Auth
{
    public class Login
    {
        [Required(ErrorMessage = "Email is required")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; set; }
    }
}
