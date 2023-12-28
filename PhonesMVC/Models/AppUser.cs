using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace PhonesMVC.Models
{
    public class AppUser : IdentityUser
    {
        public string? Nickname { get; set; }
        public string? Description { get; set; }
    }
}
