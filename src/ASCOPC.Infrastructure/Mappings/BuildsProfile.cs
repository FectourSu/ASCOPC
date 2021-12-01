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
        }
    }
}
