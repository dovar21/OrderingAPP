
namespace RDBTask.API.Application.AutoMapper;

using global::AutoMapper;

public class AutoMapperConfig
{
    public static MapperConfiguration RegisterMappings()
    {
        return new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new ProviderMappingProfile());
            cfg.AddProfile(new OrderMappingProfile());
        });
    }
}