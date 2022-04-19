using System.ComponentModel.DataAnnotations;
namespace todoapp_api.Contract.Auth
{
    public class ForgotPassword
    {
        [Required(ErrorMessage = "Email is required")]
        public string? Email { get; set; }
    }
}
