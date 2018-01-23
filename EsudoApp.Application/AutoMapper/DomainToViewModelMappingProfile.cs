using AutoMapper;
using EstudoApp.Domain.Entities;
using EsudoApp.Application.ViewModel;

namespace EsudoApp.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<NinjaViewModel, Ninja>();
        }
    }
}