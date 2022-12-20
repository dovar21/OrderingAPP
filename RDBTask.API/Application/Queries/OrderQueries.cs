namespace RDBTask.API.Application.Queries;

using global::AutoMapper;
using RDBTask.API.Application.Enums;
using RDBTask.API.Application.Models;
using RDBTask.API.Application.Models.Order;
using RDBTask.Domain.AggregatesModel.OrderAggregate;
using RDBTask.Domain.Specifications.Order;

public class OrderQueries : IOrderQueries
{
    private readonly IMapper _mapper;
    private readonly IOrderRepository _orderRepository;

    public OrderQueries(IMapper mapper, 
        IOrderRepository orderRepository)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
    }
    public async Task<BaseDataResponse<OrderResponseDTO>> FindAsync(int id)
    {
        var result = await _orderRepository.FindAsync(id);

        if (result == null)
            return BaseDataResponse<OrderResponseDTO>.Fail(null, new ErrorModel(ErrorCode.OrderNotFound));

        return BaseDataResponse<OrderResponseDTO>.Success(_mapper.Map<OrderResponseDTO>(result));
    }
    public async Task<BaseDataResponse<List<OrderResponseDTO>>> ToListAsync(OrderFilterDTO model)
    {
        var result = await _orderRepository.ToListAsync(
                    new OrderFilterSpecification(
                        model.Number,
                        model.OrderStartDate,
                        model.OrderEndDate,
                        model.ProviderId,
                        model.ItemName,
                        model.ItemUnit
                    ));
        
        return BaseDataResponse<List<OrderResponseDTO>>.Success(_mapper.Map<List<OrderResponseDTO>>(result));
    }
}