using System.ComponentModel.DataAnnotations;

namespace IdentityBlogingWebsite.ViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

    }
}
