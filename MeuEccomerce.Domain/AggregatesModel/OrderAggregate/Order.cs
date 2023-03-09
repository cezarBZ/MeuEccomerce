using MeuEccomerce.Domain.Core.Models;

namespace MeuEccomerce.Domain.AggregatesModel.OrderAggregate;

public class Order : Entity<int>, IAggregateRoot
{
    public Order(string firstName, string lastName, string address1, string address2, string zipCode, string state, string city, string phoneNumber, string email, decimal totalOrderPrice, int totalOrderItems, DateTime? orderSent, DateTime? orderDelivered)
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
        TotalOrderPrice = totalOrderPrice;
        TotalOrderItems = totalOrderItems;
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
    public decimal TotalOrderPrice { get; set; }
    public int TotalOrderItems { get; set; }
    public DateTime? OrderSent { get; set; }
    public DateTime? OrderDelivered { get; set; }
}
