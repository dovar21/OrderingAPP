namespace RDBTask.API.Application.Commands;

using System.Runtime.Serialization;

[DataContract]
public record UpdateOrderCommand : CreateOrderCommand
{
    [DataMember]
    public int Id { get; init; }
}
