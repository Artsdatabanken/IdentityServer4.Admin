using System.ComponentModel.DataAnnotations;

namespace Skoruba.IdentityServer4.STS.Identity.ViewModels.Account
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required(ErrorMessage = "{0} is required.")]
        [Display(Name = "Username")]
        [RegularExpression(@"^[a-zA-Z0-9_@\-\.\+]+$")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "{0} is required.")]
        [EmailAddress(ErrorMessage = "Not a valid e-mail address.")]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
