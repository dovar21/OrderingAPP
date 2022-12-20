namespace RDBTask.API.Application.Commands;

using global::AutoMapper;
using MediatR;
using RDBTask.API.Application.Enums;
using RDBTask.API.Application.Models;
using RDBTask.API.Application.Models.Order;
using RDBTask.Domain.AggregatesModel.OrderAggregate;

public class RemoveOrderCommandHandler
: IRequestHandler<RemoveOrderCommand, BaseDataResponse<OrderResponseDTO>>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;


    public RemoveOrderCommandHandler(IMediator mediator,
        IMapper mapper,
        IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<BaseDataResponse<OrderResponseDTO>> Handle(RemoveOrderCommand message, CancellationToken cancellationToken)
    {
        //Find order
        var order = await _orderRepository.FindAsync(message.Id);

        if (order == null)
            return BaseDataResponse<OrderResponseDTO>.Fail(null, new ErrorModel(ErrorCode.OrderNotFound));

        //Remove
        _orderRepository.Remove(order);

        //Save changes
        await _orderRepository.UnitOfWork
             .SaveEntitiesAsync(cancellationToken);

        return BaseDataResponse<OrderResponseDTO>.Success(_mapper.Map<OrderResponseDTO>(order));

    }
}