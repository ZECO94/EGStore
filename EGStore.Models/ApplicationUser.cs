using Microsoft.AspNetCore.Identity;

namespace EGStore.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public byte[]? ProfilePicture { get; set; }
        

        
    }
}
