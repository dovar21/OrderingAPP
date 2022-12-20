namespace RDBTask.API.Controllers;

using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RDBTask.API.Application.Commands;
using RDBTask.API.Application.Models;
using RDBTask.API.Application.Models.Order;
using RDBTask.API.Application.Queries;

[Route("api/[controller]")]
[ApiController]
public class OrdersController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;
    private readonly IOrderQueries _orderQueries;

    public OrdersController(IMapper mapper,
        IMediator mediator,
        IOrderQueries orderQueries)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        _orderQueries = orderQueries ?? throw new ArgumentNullException(nameof(orderQueries));
    }

    [HttpGet]
    public async Task<BaseDataResponse<List<OrderResponseDTO>>> GetOrdersAsync([FromQuery] OrderFilterDTO model)
    {
        return await _orderQueries.ToListAsync(model);
    }
    [HttpGet("{id}")]
    public async Task<BaseDataResponse<OrderResponseDTO>> GetOrderByIdAsync(int id)
    {
        return await _orderQueries.FindAsync(id);
    }
    [HttpPost]
    public async Task<BaseDataResponse<OrderResponseDTO>> CreateAsync([FromBody] CreateOrderCommand command)
    {
        return await _mediator.Send(command);
    }

    [HttpPut]
    public async Task<BaseDataResponse<OrderResponseDTO>> UpdateAsync([FromBody] UpdateOrderCommand command)
    {
        return await _mediator.Send(command);
    }

    [HttpDelete("{id:int}")]
    public async Task<BaseDataResponse<OrderResponseDTO>> RemoveAsync(int id)
    {
        return await _mediator.Send(new RemoveOrderCommand { Id = id });
    }
}