using System.ComponentModel.DataAnnotations;

namespace todoapp_api.Models.Auth
{
    public class ResetPasswordBody
    {
        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "Confirm Password is required")]
        public string? ConfirmPassword { get; set; }
    }

    public class ResetPasswordQuery
    {
        [Required(ErrorMessage = "Email is missing")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Token is missing")]
        public string? Token { get; set; }
    }
}
