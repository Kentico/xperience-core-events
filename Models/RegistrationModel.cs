using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Xperience.Core.Events
{
    public class RegistrationModel
    {
        [DisplayName("First name")]
        public string FirstName { get; set; }

        [DisplayName("Last name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter your email")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address")]
        [DisplayName("Email")]
        [MaxLength(250, ErrorMessage = "Maximum allowed length of the email is {1}")]
        public string Email { get; set; }
    }
}
