using Microsoft.AspNetCore.Identity;

namespace Labs.Models
{
    public class ApplicationUser : IdentityUser // => prepared 
    {           
        public string? FirstName { get; set; }
        public string? LastName { get; set; }


    }
}
