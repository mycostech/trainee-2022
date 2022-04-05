using System.ComponentModel.DataAnnotations;
namespace todoapp_api.Models.Auth
{
    public class ForgotPassword
    {
        [Required(ErrorMessage = "Email is required")]
        public string? Email { get; set; }
    }
}
