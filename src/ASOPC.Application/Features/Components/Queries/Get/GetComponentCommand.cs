using ASCOPC.Domain.Contracts;
using ASCOPC.Domain.Entities;
using ASCOPC.Shared;
using ASOPC.Application.Interfaces.Data;
using AutoMapper;
using MediatR;

namespace ASOPC.Application.Features.Components.Queries.Get
{
    public class GetComponentCommand : IRequest<IResult<GetComponentResponse>>
    {
        public int Id { get; set; }

        public class GetComponentCommandHandler : IRequestHandler<GetComponentCommand, IResult<GetComponentResponse>>
        {
            private readonly IUnitOfWork unitOfWork;
            private readonly IMapper mapper;

            public GetComponentCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                this.unitOfWork = unitOfWork;
                this.mapper = mapper;
            }

            public async Task<IResult<GetComponentResponse>> Handle(GetComponentCommand request, CancellationToken cancellationToken)
            {
                var result = OperationResult<GetComponentResponse>.CreateBuilder();
                var repository = unitOfWork.Repository<Component>();

                var entity = await repository.GetByIdAsync(request.Id);

                if(entity is null)
                {
                    result.AppendError($"Entity not found: {request.Id}");
                }

                var response = mapper.Map<GetComponentResponse>(entity);
                return result.SetValue(response).BuildResult();
            }
        }
    }
}
