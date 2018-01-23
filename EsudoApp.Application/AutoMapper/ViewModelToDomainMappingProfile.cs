using AutoMapper;
using EstudoApp.Domain.Entities;
using EsudoApp.Application.ViewModel;

namespace EsudoApp.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<Ninja, NinjaViewModel>();
        }
    }
}