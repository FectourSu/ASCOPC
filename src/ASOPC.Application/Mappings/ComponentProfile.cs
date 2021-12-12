using ASCOPC.Domain.Entities;
using ASCOPC.Shared.DTO;
using ASOPC.Application.Features.Components.Commands.Create;
using ASOPC.Application.Features.Components.Commands.Update;
using ASOPC.Application.Features.Components.Queries;
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

            CreateMap<CreateComponentCommand, ComponentsDTO>();
            CreateMap<ComponentsDTO, CreateComponentCommand>();

            CreateMap<Component, Component>()
                .ForMember(c => c.Id, opt => opt.Ignore())
                .ForMember(c => c.CreateAt, opt => opt.Ignore());

            CreateMap<ComponentsDTO, Component>();
            CreateMap<Component, ComponentsDTO>()
                .ForMember(c => c.Specification, opt => 
                    opt.MapFrom(c => c.SpecificationComponent.Where(sc => sc.ComponentId == c.Id)
                        .Select(sc => sc.Specifications)))
                .ForMember(c => c.Manufacturer, opt => opt.MapFrom(s => s.Manufacturer.Name))
                .ForMember(c => c.Type, opt => opt.MapFrom(s=> s.Type.Name));

            CreateMap<Component, CreateComponentCommand>();
            CreateMap<CreateComponentCommand, Component>()
                .ForMember(c => c.SpecificationComponent, opt => opt.Ignore())
                .ForMember(c => c.Manufacturer, opt => opt.Ignore())
                .ForMember(c => c.Type, opt => opt.Ignore());

            CreateMap<Component, UpdateComponentCommand>();
            CreateMap<UpdateComponentCommand, Component>()
                .ForMember(c => c.SpecificationComponent, opt => opt.Ignore())
                .ForMember(c => c.Manufacturer, opt => opt.Ignore())
                .ForMember(c => c.Type, opt => opt.Ignore());

            CreateMap<GetFilteredComponentCommand, ComponentsDTO>();
            CreateMap<ComponentsDTO, GetFilteredComponentCommand>();

            CreateMap<GetFilteredComponentCommand, Component>();
            CreateMap<Component, GetFilteredComponentCommand>();
        }
    }
}
