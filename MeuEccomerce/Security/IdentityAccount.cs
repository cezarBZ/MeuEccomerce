using Microsoft.AspNetCore.Identity;

namespace MeuEccomerce.API.Security
{
    public class IdentityAccount : IdentityUser
    {
        public string Name { get; set; }
    }
    
}
