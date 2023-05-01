namespace MeuEccomerce.Domain.AggregatesModel.OrderAggregate
{
    public enum OrderStatus
    {
        Created = 1,
        WaitingForPayment = 2 ,
        Delivered = 3,
        OnTheWay = 4,
    }
}