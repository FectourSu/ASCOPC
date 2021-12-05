using ASCOPC.Domain.Entities;
using ASCOPC.Shared.DTO;
using AutoMapper;

namespace ASCOPC.Infrastructure.Mappings
{
    public class BuildsProfile : Profile
    {
        public BuildsProfile()
        {
            CreateMap<Builds, BuildsDTO>();
            CreateMap<BuildsDTO, Builds>();

            CreateMap<Builds, BuildsComponentsDTO>()
                .ForMember(c => c.ComponentsIds, opt => opt.Ignore());
            CreateMap<BuildsComponentsDTO, ComponentBuilds>()
                .ForMember(c => c.ComponentId, opt => opt.Ignore());
            //CreateMap<Builds, ComponentBuilds>()
            //    .ForMember(c => c.Components, opt => opt.Ignore());


            CreateMap<Builds, BuildsComponentsDTO>()
                .ForMember(c => c.ComponentsIds, opt => opt.Ignore());
            CreateMap<BuildsComponentsDTO, Builds>();
        }
    }
}
