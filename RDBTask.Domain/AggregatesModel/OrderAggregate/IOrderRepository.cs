namespace RDBTask.Domain.AggregatesModel.OrderAggregate; 

using RDBTask.Domain.SeedWork;

public interface IOrderRepository : IRepository<Order>
{
    Order Add(Order order);
    void Update(Order order);
    void Remove(Order order);
    Task<Order> FindAsync(int id);
    Task<Order> FindAsync(ISpecification<Order> spec);
    Task<List<Order>> ToListAsync(ISpecification<Order> spec);

}

