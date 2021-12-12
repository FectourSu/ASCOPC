using ASCOPC.Domain.Entities;
using ASOPC.Application.Features.Builds.Commands;
using ASOPC.Application.Features.Builds.Commands.Create;
using ASOPC.Application.Features.Builds.Commands.Update;
using ASOPC.Application.Features.Builds.Queries.Get;
using AutoMapper;

namespace ASCOPC.Infrastructure.Mappings
{
    public class BuildsProfile : Profile
    {
        public BuildsProfile()
        {
            CreateMap<Builds, GetBuildResponse>();
            CreateMap<GetBuildResponse, Builds>();

            CreateMap<Builds, CreateBuildCommand>()
                .ForMember(c => c.ComponentsIds, opt => opt.Ignore());
            CreateMap<CreateBuildCommand, ComponentBuilds>()
                .ForMember(c => c.ComponentId, opt => opt.Ignore());

            CreateMap<Builds, BuildCommand>()
                .ForMember(c => c.ComponentsIds, opt => opt.Ignore());
            CreateMap<BuildCommand, Builds>();

            CreateMap<Builds, CreateBuildCommand>()
                .ForMember(c => c.ComponentsIds, opt => opt.Ignore());
            CreateMap<CreateBuildCommand, Builds>();

            CreateMap<Builds, UpdateBuildCommand>()
                .ForMember(c => c.ComponentsIds, opt => opt.Ignore());
            CreateMap<UpdateBuildCommand, Builds>();
        }
    }
}
