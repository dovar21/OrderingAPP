using RDBTask.API.Application.Models;
using RDBTask.API.Application.Models.Order;

namespace RDBTask.API.Application.Queries;

public interface IOrderQueries
{
    Task<BaseDataResponse<OrderResponseDTO>> FindAsync(int id);
    Task<BaseDataResponse<List<OrderResponseDTO>>> ToListAsync(OrderFilterDTO model);
}