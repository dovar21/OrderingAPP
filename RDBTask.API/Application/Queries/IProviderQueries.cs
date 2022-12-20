namespace RDBTask.API.Application.Queries;

public interface IProviderQueries
{
    Task<IEnumerable<ProviderResponseModel>> ToListAsync();
}