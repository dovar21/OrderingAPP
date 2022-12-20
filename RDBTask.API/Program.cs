using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RDBTask.API.Application.AutoMapper;
using RDBTask.API.Controllers;
using RDBTask.API.Infrastructure.AutofacModules;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;
// Add services to the container.
services.AddControllers()
    .AddApplicationPart(typeof(OrdersController).Assembly)
    .AddApplicationPart(typeof(ProvidersController).Assembly)
            .AddJsonOptions(options => options.JsonSerializerOptions.WriteIndented = true);

services.AddDbContext<RDBTask.Infrastructure.RDBTaskDbContext>(
    options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("RDBTaskDb"), b => b.MigrationsAssembly("RDBTask.API"));
    },
    ServiceLifetime.Scoped
);

var mappingConfig = AutoMapperConfig.RegisterMappings();

IMapper mapper = mappingConfig.CreateMapper();
services.AddSingleton(mapper);

services.AddControllers().AddJsonOptions(opts => {
    opts.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
});

services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

services.AddRouting(options => options.LowercaseUrls = true);

var host = builder.Host;

host.ConfigureContainer<ContainerBuilder>(cb=> cb.RegisterModule(new MediatorModule()));
host.ConfigureContainer<ContainerBuilder>(cb=> cb.RegisterModule(new ApplicationModule(builder.Configuration.GetConnectionString("RDBTaskDb"))));

host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapControllers();

app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Run();
