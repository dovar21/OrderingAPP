namespace RDBTask.API.Application.Commands;

using global::AutoMapper;
using MediatR;
using RDBTask.API.Application.Enums;
using RDBTask.API.Application.Models;
using RDBTask.API.Application.Models.Order;
using RDBTask.Domain.AggregatesModel.OrderAggregate;
using RDBTask.Domain.AggregatesModel.ProviderAggregate;
using RDBTask.Domain.Specifications.Order;

public class UpdateOrderCommandHandler
: IRequestHandler<UpdateOrderCommand, BaseDataResponse<OrderResponseDTO>>
{
    private readonly IProviderRepository _providerRepository;
    private readonly IOrderRepository _orderRepository;
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public UpdateOrderCommandHandler(IMediator mediator,
        IMapper mapper,
        IOrderRepository orderRepository,
        IProviderRepository providerRepository)
    {
        _providerRepository = providerRepository ?? throw new ArgumentNullException(nameof(providerRepository));
        _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<BaseDataResponse<OrderResponseDTO>> Handle(UpdateOrderCommand message, CancellationToken cancellationToken)
    {
        //Find order
        var order = await _orderRepository.FindAsync(message.Id);

        if (order == null)
            return BaseDataResponse<OrderResponseDTO>.Fail(null, new ErrorModel(ErrorCode.OrderNotFound));
        var x = message.ProviderId;
        //Find provider
        var provider = await _providerRepository.FindAsync(message.ProviderId);

        if (provider == null)
            return BaseDataResponse<OrderResponseDTO>.Fail(null, new ErrorModel(ErrorCode.ProviderNotFound));

        //Check order by number and provider id
        if (await _orderRepository.FindAsync(
                new OrderUniquenessCheckSpecification(
                    message.Id,
                    message.Number,
                    message.ProviderId)) != null
            )
            return BaseDataResponse<OrderResponseDTO>.Fail(null, new ErrorModel(ErrorCode.OrderNumberForProviderMustBeUnique));

        //Check order number in order items
        if (order.OrderItems.Any(i => i.Name == message.Number))
            return BaseDataResponse<OrderResponseDTO>.Fail(null, new ErrorModel(ErrorCode.OrderItemNameCannotBeEqualOrderNumber));


        order.SetNumber(message.Number);
        order.SetOrderDate(message.OrderDate);
        order.SetProviderId(message.ProviderId);

        //Clear order items before saving
        order.ClearOrderItems();

        //Add order items
        foreach (var item in message.OrderItems)
            order.AddOrderItem(item.Name, item.Quantity, item.Unit);

        //Update
        _orderRepository.Update(order);

        //Save changes
        await _orderRepository.UnitOfWork
             .SaveEntitiesAsync(cancellationToken);

        return BaseDataResponse<OrderResponseDTO>.Success(_mapper.Map<OrderResponseDTO>(order));

    }
}
