using System.ComponentModel.DataAnnotations;
namespace todoapp_api.Models.Auth
{
    public class Register
    {
        [Required(ErrorMessage = "User Name is required")]
        public string? Name { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; set; }
    }
}
