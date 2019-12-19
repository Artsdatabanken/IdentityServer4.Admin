using System.ComponentModel.DataAnnotations;

namespace Skoruba.IdentityServer4.STS.Identity.ViewModels.Manage
{
    public class IndexViewModel
    {
        public string Username { get; set; }

        public bool IsEmailConfirmed { get; set; }

        [Required(ErrorMessage = "{0} is required.")]
        [EmailAddress(ErrorMessage = "Not a valid e-mail address.")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Phone(ErrorMessage = "Phone number not a valid.")]
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }

        public string StatusMessage { get; set; }

        [Required(ErrorMessage = "{0} is required.")]
        [MaxLength(127, ErrorMessage = "Maximum length of {1} characters.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "{0} is required.")]
        [MaxLength(128, ErrorMessage = "Maximum length of {1} characters.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [MaxLength(255, ErrorMessage = "Maximum length of {1} characters.")]
        [Display(Name = "Website")]
        public string Website { get; set; }

        [MaxLength(255, ErrorMessage = "Maximum length of {1} characters.")]
        [Display(Name = "Profile")]
        public string Profile { get; set; }

        [MaxLength(255, ErrorMessage = "Maximum length of {1} characters.")]
        [Display(Name = "Street Address")]
        public string StreetAddress { get; set; }

        [MaxLength(255, ErrorMessage = "Maximum length of {1} characters.")]
        [Display(Name = "City")]
        public string Locality { get; set; }

        [MaxLength(255, ErrorMessage = "Maximum length of {1} characters.")]
        [Display(Name = "Region")]
        public string Region { get; set; }

        [MaxLength(255, ErrorMessage = "Maximum length of {1} characters.")]
        [Display(Name = "Postal Code")]
        public string PostalCode { get; set; }

        [MaxLength(255, ErrorMessage = "Maximum length of {1} characters.")]
        [Display(Name = "Country")]
        public string Country { get; set; }
    }
}
