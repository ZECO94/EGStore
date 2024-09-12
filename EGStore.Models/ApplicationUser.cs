using Microsoft.AspNetCore.Identity;

namespace EGStore.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string PhoneNumber {  get; set; }
    }
}
