using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace CoraCorpCM.Domain
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser() : base()
        {
        }

        public Museum Museum { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
