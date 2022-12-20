namespace RDBTask.Domain.Specifications.Order;

using RDBTask.Domain.SeedWork;
using System;

public class OrderUniquenessCheckSpecification : BaseSpecification<AggregatesModel.OrderAggregate.Order>
{
    public OrderUniquenessCheckSpecification(int? id, string number, int? providerId)
        : base(i => (!(id > 0) ||  i.Id != id) &&
        (!(id > 0) || i.Id == id) &&
        (!(number != null) || i.Number == number) &&
        (!(providerId > 0) || i.ProviderId == providerId))
    {

    }
}