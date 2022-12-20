namespace RDBTask.API.Application.Commands;

using MediatR;
using RDBTask.API.Application.Models;
using RDBTask.API.Application.Models.Order;
using System.Runtime.Serialization;

[DataContract]
public record CreateOrderCommand
: IRequest<BaseDataResponse<OrderResponseDTO>>
{
    [DataMember]
    private readonly List<OrderItemDTO> _orderItems;

    [DataMember]
    public string Number { get; init; }

    [DataMember]
    public DateTime OrderDate { get; init; }

    [DataMember]
    public int ProviderId { get; init; }

    [DataMember]
    public IEnumerable<OrderItemDTO> OrderItems { get; init; }

    public CreateOrderCommand()
    {
        _orderItems = new List<OrderItemDTO>();
    }

    public CreateOrderCommand(string number, DateTime orderDate, int providerId) : this()
    {
        Number = number;
        OrderDate = orderDate;
        ProviderId = providerId;
    }

    public record OrderItemDTO
    {
        public string Name { get; init; }
        public decimal Quantity { get; init; }
        public string Unit { get; init; }
    }
}