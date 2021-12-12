using ASCOPC.Domain.Contracts;
using ASCOPC.Domain.Entities;
using ASCOPC.Shared;
using ASCOPC.Shared.DTO;
using ASOPC.Application.Interfaces.Data;
using AutoMapper;
using MediatR;

namespace ASOPC.Application.Features.Components.Queries.GetAll
{
    public class GetAllComponentCommand : IRequest<IResult<IEnumerable<ComponentsDTO>>>
    {
        public GetAllComponentCommand()
        {
        }
        public class GetComponentCommandHandler : IRequestHandler<GetAllComponentCommand,
            IResult<IEnumerable<ComponentsDTO>>>
        {
            private readonly IUnitOfWork unitOfWork;
            private readonly IMapper mapper;

            public GetComponentCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                this.unitOfWork = unitOfWork;
                this.mapper = mapper;
            }

            public async Task<IResult<IEnumerable<ComponentsDTO>>> Handle(GetAllComponentCommand request,
                CancellationToken cancellationToken)
            {
                var result = OperationResult<IEnumerable<ComponentsDTO>>.CreateBuilder();
                var repository = unitOfWork.Repository<Component>();
                var entity = await repository.GetAllAsync();

                if (entity is null)
                    result.AppendError($"Entity not found: {request}");

                var response = mapper.Map<IEnumerable<ComponentsDTO>>(entity);
                return result.SetValue(response).BuildResult();
            }
        }
    }
}
