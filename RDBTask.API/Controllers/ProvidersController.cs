namespace RDBTask.API.Controllers;

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RDBTask.API.Application.Models;
using RDBTask.API.Application.Queries;

[Route("api/[controller]")]
[ApiController]
public class ProvidersController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IProviderQueries _providerQueries;
    public ProvidersController(IProviderQueries providerQueries, IMapper mapper)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _providerQueries = providerQueries ?? throw new ArgumentNullException(nameof(providerQueries));
    }

    [HttpGet]
    public async Task<BaseDataResponse<List<ProviderResponseModel>>> GetProvidersAsync()
    {
        var providers = await _providerQueries.ToListAsync();

        return BaseDataResponse<List<ProviderResponseModel>>.Success(_mapper.Map<List<ProviderResponseModel>>(providers));
    }
}