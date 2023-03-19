using MediatR;

namespace MeuEccomerce.API.Application.Commands.Orders
{
    public class CreateOrderCommand : IRequest<bool>
    {
        public CreateOrderCommand(string firstName, string lastName, string address1, string address2, string zipCode, string state, string city, string phoneNumber, string email, DateTime? orderSent, DateTime? orderDelivered)
        {
            FirstName = firstName;
            LastName = lastName;
            Address1 = address1;
            Address2 = address2;
            ZipCode = zipCode;
            State = state;
            City = city;
            PhoneNumber = phoneNumber;
            Email = email;
            OrderSent = orderSent;
            OrderDelivered = orderDelivered;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string ZipCode { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime? OrderSent { get; set; }
        public DateTime? OrderDelivered { get; set; }
    }
}
