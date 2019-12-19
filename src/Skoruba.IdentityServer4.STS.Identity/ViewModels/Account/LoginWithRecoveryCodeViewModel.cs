using System.ComponentModel.DataAnnotations;

namespace Skoruba.IdentityServer4.STS.Identity.ViewModels.Account
{
    public class LoginWithRecoveryCodeViewModel
    {
        [Required(ErrorMessage = "{0} is required.")]
        [DataType(DataType.Text)]
        [Display(Name = "Recovery Code")]
        public string RecoveryCode { get; set; }

        public string ReturnUrl { get; set; }
    }
}
