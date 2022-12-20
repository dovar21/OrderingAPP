namespace RDBTask.API.Application.Models.Order;

using System;

public class OrderResponseDTO
{
    public int Id { get; private set; }
    public string Number { get; private set; }
    public DateTime OrderDate { get; private set; }
    public int ProviderId { get; private set; }
    public IList<OrderItemResponseDTO> OrderItems { get; private set; }
}
public class OrderItemResponseDTO
{
    public int Id { get; private set; }
    public int OrderId { get; private set; }
    public string Name { get; private set; }
    public decimal Quantity { get; private set; }
    public string Unit { get; private set; }
}