namespace RDBTask.API.Application.AutoMapper;

using global::AutoMapper;
using RDBTask.API.Application.Models.Order;
using RDBTask.Domain.AggregatesModel.OrderAggregate;

public class OrderMappingProfile : Profile
{
    public OrderMappingProfile()
    {
        //Response
        CreateMap<Order, OrderResponseDTO>();

        CreateMap<OrderItem, OrderItemResponseDTO>();

    }
}