using ASCOPC.Infrastructure.Data.Entities;
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
            CreateMap<BuildsComponentsDTO, Builds>()
                .ForMember(c => c.Components, opt => opt.Ignore());           
        }
    }
}
