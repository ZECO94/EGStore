using Microsoft.AspNetCore.Identity;

namespace EGStore.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Address { get; set; }
        public string PhoneNumber {  get; set; }
    }
}
