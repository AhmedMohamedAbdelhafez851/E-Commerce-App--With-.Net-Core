using Microsoft.AspNetCore.Identity;

namespace Labs.Models
{
    public class ApplicationRole : IdentityRole

    {
        public string? RolePermissions {get;set;}  // json => Key  | Value
                                                   //         Add  | Admin
                                                   //         Edit | Sales


    }
}
