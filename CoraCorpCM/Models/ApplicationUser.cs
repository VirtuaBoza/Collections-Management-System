using Microsoft.AspNetCore.Identity;

namespace CoraCorpCM.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public Museum Museum { get; set; }
    }
}
