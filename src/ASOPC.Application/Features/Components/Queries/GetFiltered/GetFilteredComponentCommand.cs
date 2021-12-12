using ASCOPC.Domain.Contracts;
using ASCOPC.Domain.Entities;
using ASCOPC.Shared;
using ASCOPC.Shared.DTO;
using ASOPC.Application.Interfaces.Data;
using ASOPC.Application.Interfaces.Services;
using AutoMapper;
using MediatR;

namespace ASOPC.Application.Features.Components.Queries
{
    public class GetFilteredComponentCommand : IRequest<IResult<IEnumerable<ComponentsDTO>>>
    {
        public string Type { get; set; }
        public IEnumerable<SpecificationsDTO> Specifications { get; set; }

        public class GetFilteredComponentCommandHandler : IRequestHandler<GetFilteredComponentCommand, 
            IResult<IEnumerable<ComponentsDTO>>>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;
            private readonly IComponentMapService _componentService;

            public GetFilteredComponentCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IComponentMapService component)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
                _componentService = component;
            }

            public async Task<IResult<IEnumerable<ComponentsDTO>>> Handle(GetFilteredComponentCommand request,
                CancellationToken cancellationToken)
            {
                var result = OperationResult<IEnumerable<ComponentsDTO>>.CreateBuilder();
                var repository = _unitOfWork.Repository<Component>();

                var selectEntities = repository.Entities
                    .Where(s => s.Type.Name.ToLower() == request.Type.ToLower());

                if (!selectEntities.Any())
                    return result.AppendError($"Type not found: {request.Type}").BuildResult();

                var filterEntities = await _componentService.FilterComponentsBySpecifications(selectEntities, 
                    _mapper.Map<IEnumerable<Specifications>>(request.Specifications));

                if (!filterEntities.Any())
                    return result.AppendError($"Specification is not found").BuildResult();

                var response = _mapper.Map<IEnumerable<ComponentsDTO>>(filterEntities);

                return result.SetValue(response).BuildResult();
            }
        }
    }
}
