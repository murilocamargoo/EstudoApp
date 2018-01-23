using AutoMapper;

namespace EsudoApp.Application.AutoMapper
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile(new DomainToViewModelMappingProfile());

                cfg.AddProfile(new ViewModelToDomainMappingProfile());
            });
        }
    }
}
