namespace RDBTask.API.Application.Enums;

using System.ComponentModel;

public enum ErrorCode
{
    [Description("Order not found")]
    OrderNotFound = 100,
    [Description("Order number for provider must be unique ")]
    OrderNumberForProviderMustBeUnique = 101,
    [Description("Provider not found")]
    ProviderNotFound = 102,
    [Description("Order item name cannot be equal order number")]
    OrderItemNameCannotBeEqualOrderNumber = 103,

}