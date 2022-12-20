namespace RDBTask.Domain.SeedWork;

using System;
using System.Linq.Expressions;

public interface ISpecification<T>
{
    Expression<Func<T, bool>> Criteria { get; }
}
