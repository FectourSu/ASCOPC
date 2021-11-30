using ASCOPC.Domain.Contracts;
using ASCOPC.Domain.Entities;
using ASCOPC.Shared;
using ASCOPC.Shared.DTO;
using ASOPC.Application.Interfaces.Data;
using ASOPC.Application.Interfaces.Services;
using AutoMapper;
using MediatR;

namespace ASOPC.Application.Features.Components.Commands.Create
{
    public class CreateComponentCommand : ComponentCommand
    {
        public class CreateComponentsHandler : IRequestHandler<CreateComponentCommand, IResult>
        {
            private readonly IMapper _mapper;
            private readonly IComponentMapService _componentService;
            private readonly IUnitOfWork _unitOfWork;

            public CreateComponentsHandler(IUnitOfWork unitOfWork, IMapper mapper, IComponentMapService componentService)
            {
                _mapper = mapper;
                _unitOfWork = unitOfWork;
                _componentService = componentService;
            }
            public async Task<IResult> Handle(CreateComponentCommand request, CancellationToken cancellationToken)
            {
                var result = OperationResult.CreateBuilder();

                var repository = _unitOfWork.Repository<Component>();
                var entity = new Component();

                await _componentService.ComponentMappingAsync(request, entity);

                try
                {
                    await repository.AddEntity(entity);
                    await _unitOfWork.SaveChangeAsync(cancellationToken);
                }
                catch (Exception ex)
                {
                    if (entity is not null)
                    {
                        await repository.DeleteEntity(entity);
                        await _componentService.TryUpdateAsync(entity);
                    }

                    result.AppendError(ex.Message);
                }

                return result.BuildResult();
            }
        }
    }
}
