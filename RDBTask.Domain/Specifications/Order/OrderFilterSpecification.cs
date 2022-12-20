namespace RDBTask.Domain.Specifications.Order;

using RDBTask.Domain.SeedWork;
using System;

public class OrderFilterSpecification : BaseSpecification<AggregatesModel.OrderAggregate.Order>
{
    public OrderFilterSpecification(string number, DateTime? startDate, DateTime? endDate, int? providerId, string itemName, string itemUnit)
        : base(i => 
        (!(number != null) || i.Number == number) &&
        (!(startDate.HasValue) || i.OrderDate >= startDate) &&
        (!(endDate.HasValue) || i.OrderDate <= endDate) &&
        (!(providerId > 0) || i.ProviderId == providerId) &&
        (!(itemName != null) || i.OrderItems.Any(oi=>oi.Name == itemName)) &&
        (!(itemUnit != null) || i.OrderItems.Any(oi => oi.Unit == itemUnit)))
    {

    }
}