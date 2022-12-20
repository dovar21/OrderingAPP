namespace RDBTask.Infrastructure.Repositories;

using Microsoft.EntityFrameworkCore;
using RDBTask.Domain.AggregatesModel.OrderAggregate;
using RDBTask.Domain.SeedWork;

public class OrderRepository: IOrderRepository
{
    private readonly RDBTaskDbContext _context;

    public IUnitOfWork UnitOfWork
    {
        get
        {
            return _context;
        }
    }

    public OrderRepository(RDBTaskDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public Order Add(Order order)
    {
        if (order.IsTransient())
            return _context.Orders.Add(order).Entity;
        else
            return order;
    }

    public async Task<Order> FindAsync(int id)
    {
        var order = await _context
                            .Orders
                            .FirstOrDefaultAsync(o => o.Id == id);
        if (order != null)
            await _context.Entry(order).Collection(i => i.OrderItems).LoadAsync();

        return order;
    }
    //Find by specification
    public async Task<Order> FindAsync(ISpecification<Order> spec)
    {
        return await ApplySpecification(spec).SingleOrDefaultAsync();
    }
    //Find all by specification
    public async Task<List<Order>> ToListAsync(ISpecification<Order> spec)
    {
        return await ApplySpecification(spec).Include(i=>i.OrderItems).ToListAsync();
    }
    public void Update(Order order)
    {
        _context.Entry(order).State = EntityState.Modified;
    }
    public void Remove(Order order)
    {
        _context.Orders.Remove(order);
    }
    //Apply specification
    private IQueryable<Order> ApplySpecification(ISpecification<Order> spec)
    {
        return SpecificationEvaluator<Order>.GetQuery(_context.Set<Order>().AsQueryable(), spec);
    }
}
