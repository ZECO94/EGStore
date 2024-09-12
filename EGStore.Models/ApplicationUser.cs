using Microsoft.AspNetCore.Identity;

namespace MyStore.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string PhoneNumber {  get; set; }
    }
}
