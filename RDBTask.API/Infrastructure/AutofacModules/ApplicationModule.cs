namespace RDBTask.API.Infrastructure.AutofacModules;

using Autofac;
using RDBTask.API.Application.Queries;
using RDBTask.Domain.AggregatesModel.OrderAggregate;
using RDBTask.Domain.AggregatesModel.ProviderAggregate;
using RDBTask.Infrastructure.Repositories;

public class ApplicationModule : Module
{
    public string QueriesConnectionString { get; }

    public ApplicationModule(string qconstr)
    {
        QueriesConnectionString = qconstr;
    }
    protected override void Load(ContainerBuilder builder)
    {
        builder.Register(c => new ProviderQueries(QueriesConnectionString))
       .As<IProviderQueries>()
       .InstancePerLifetimeScope();

        builder.RegisterType<OrderQueries>()
        .As<IOrderQueries>()
        .InstancePerLifetimeScope();

        builder.RegisterType<ProviderRepository>()
        .As<IProviderRepository>()
        .InstancePerLifetimeScope();

        builder.RegisterType<OrderRepository>()
        .As<IOrderRepository>()
        .InstancePerLifetimeScope();
    }
}
