using Microsoft.AspNetCore.Identity;

namespace BOROMOTORS.Models
{
    public class ApplicationUser : IdentityUser
    {
        public required string DisplayName { get; set; }
    }
}
