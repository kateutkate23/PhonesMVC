using System.ComponentModel.DataAnnotations;

namespace PhonesMVC.ViewModels
{
    public class LoginVM
    {
        [Required]
        [Display(Name = "Email address")]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
