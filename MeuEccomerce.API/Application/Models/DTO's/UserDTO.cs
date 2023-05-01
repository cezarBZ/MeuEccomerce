using MeuEccomerce.Domain.AggregatesModel.UserAggregate;

namespace MeuEccomerce.API.Application.Models.DTO_s
{
    public class UserDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string UserName { get; set; }
        public UserAddressDTO Address { get; set; }
    }
}
