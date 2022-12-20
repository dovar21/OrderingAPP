
namespace RDBTask.Domain.AggregatesModel.OrderAggregate;

using RDBTask.Domain.SeedWork;

public class Order: Entity, IAggregateRoot
{
    public string Number { get; private set; }
    public DateTime OrderDate { get; private set; }
    public int ProviderId { get; private set; }

    private List<OrderItem> _orderItems;
    public IReadOnlyCollection<OrderItem> OrderItems => _orderItems;

    protected Order()
    {
        _orderItems = new();
    }

    public Order(string number, DateTime date, int providerId) : this()
    {
        Number = number;
        ProviderId = providerId;
        OrderDate = date;
    }

    public void AddOrderItem(string name, decimal quantity, string unit)
    {
        var orderItem = new OrderItem( name, quantity, unit);
        
        _orderItems.Add(orderItem);
    }

    public void ClearOrderItems()
    {
        _orderItems = new();
    }

    public void SetProviderId(int id)
    {
        ProviderId = id;
    }
    public void SetNumber(string number)
    {
        Number = number;
    }
    public void SetOrderDate(DateTime orderDate)
    {
        OrderDate = orderDate;
    }
}
