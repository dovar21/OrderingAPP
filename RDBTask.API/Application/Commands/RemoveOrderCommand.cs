namespace RDBTask.API.Application.Commands;

using MediatR;
using RDBTask.API.Application.Models;
using RDBTask.API.Application.Models.Order;
using System.Runtime.Serialization;

[DataContract]
public record RemoveOrderCommand
: IRequest<BaseDataResponse<OrderResponseDTO>>
{
    [DataMember]
    public int Id { get; init; }
}