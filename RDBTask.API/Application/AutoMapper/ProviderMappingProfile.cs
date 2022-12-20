namespace RDBTask.API.Application.AutoMapper;

using global::AutoMapper;
using RDBTask.API.Application.Queries;
using RDBTask.Domain.AggregatesModel.ProviderAggregate;

public class ProviderMappingProfile : Profile
{
    public ProviderMappingProfile()
    {
        //Response
        CreateMap<Provider, ProviderResponseModel>();
    }
}