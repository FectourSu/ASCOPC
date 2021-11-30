using ASCOPC.Domain.Entities;
using ASCOPC.Shared.DTO;
using ASOPC.Application.Features.Components.Commands.Create;
using ASOPC.Application.Features.Components.Commands.Update;
using ASOPC.Application.Features.Components.Queries.Get;
using AutoMapper;

namespace ASOPC.Application.Mappings
{
    public class ComponentProfile : Profile
    {
        public ComponentProfile()
        {
            CreateMap<Specifications, SpecificationsDTO>();
            CreateMap<SpecificationsDTO, Specifications>();

            CreateMap<Component, Component>()
                .ForMember(c => c.Id, opt => opt.Ignore())
                .ForMember(c => c.CreateAt, opt => opt.Ignore());

            CreateMap<Component, ComponentsDTO>()
                .ForMember(c => c.Specification, opt => opt.Ignore())
                .ForMember(c => c.Manufacturer, opt => opt.Ignore())
                .ForMember(c => c.Type, opt => opt.Ignore());

            CreateMap<Component, GetComponentResponse>();

            CreateMap<CreateComponentCommand, Component>()
                .ForMember(c => c.SpecificationComponent, opt => opt.Ignore())
                .ForMember(c => c.Manufacturer, opt => opt.Ignore())
                .ForMember(c => c.Type, opt => opt.Ignore());

            CreateMap<UpdateComponentCommand, Component>();

            CreateMap<CreateComponentCommand, ComponentsDTO>();
            CreateMap<ComponentsDTO, CreateComponentCommand>();

        }
    }
}
