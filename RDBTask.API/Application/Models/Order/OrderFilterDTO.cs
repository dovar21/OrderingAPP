namespace RDBTask.API.Application.Models.Order;

using System;

public class OrderFilterDTO
{
    public string? Number { get; init; }
    public DateTime? OrderStartDate { get; init; }
    public DateTime? OrderEndDate { get; init; }
    public int? ProviderId { get; init; }
    public string? ItemName{ get; init; }
    public string? ItemUnit { get; init; }

}