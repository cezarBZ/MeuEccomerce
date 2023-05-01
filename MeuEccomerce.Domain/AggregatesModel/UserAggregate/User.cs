using MeuEccomerce.Domain.Core.Models;
using Microsoft.AspNetCore.Identity;


namespace MeuEccomerce.Domain.AggregatesModel.UserAggregate
{
    public class User : IdentityUser
    { 
        public string FullName { get; set; }
        public DateTime AccountCreationDate { get; set; }
        public DateTime? LastLoginDate { get; set; } 
        public UserAddress Address { get; set; }
    }
}
