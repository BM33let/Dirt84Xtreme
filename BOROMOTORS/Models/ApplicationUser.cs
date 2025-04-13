using Microsoft.AspNetCore.Identity;

namespace BOROMOTORS.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string DisplayName { get; set; }
    }
}
