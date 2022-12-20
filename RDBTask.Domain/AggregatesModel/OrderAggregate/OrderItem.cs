namespace RDBTask.Domain.AggregatesModel.OrderAggregate;

using RDBTask.Domain.SeedWork;

public class OrderItem
    : Entity
{
    public Order Order { get; private set; }
    public int OrderId { get; private set; }
    public string Name { get; private set; }
    public decimal Quantity { get; private set; }
    public string Unit { get; private set; }

    protected OrderItem() { }

    public OrderItem(string name, decimal quantity, string unit)
    {
        if (quantity <= 0)
        {
            throw new Exception("Invalid quantity");
        }

        Name = name;
        Quantity = quantity;
        Unit = unit;
    }
    public void SetName(string name)
    {
        Name = name;
    }
    public void SetQuantity(decimal quantity)
    {
        if (quantity <= 0)
        {
            throw new Exception("Invalid quantity");
        }

        Quantity = quantity;
    }
    public void SetUnit(string unit)
    {
        Unit = unit;
    }
}
