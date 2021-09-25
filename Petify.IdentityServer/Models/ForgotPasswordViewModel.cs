using System.ComponentModel.DataAnnotations;

namespace Petify.IdentityServer.Models
{
    public class ForgotPasswordViewModel
    {
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress]
        public string Email { get; set; }
    }
}
