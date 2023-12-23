using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace PhonesMVC.ViewModels
{
    public class AddUserVM : IdentityUser
    {
        public string? Nickname { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string? Description { get; set; }
    }
}
