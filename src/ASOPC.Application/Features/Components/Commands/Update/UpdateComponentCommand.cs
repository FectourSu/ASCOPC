using ASCOPC.Domain.Contracts;
using ASCOPC.Domain.Entities;
using ASCOPC.Shared;
using ASCOPC.Shared.DTO;
using ASOPC.Application.Interfaces.Data;
using ASOPC.Application.Interfaces.Services;
using AutoMapper;
using MediatR;

namespace ASOPC.Application.Features.Components.Commands.Update
{
    public class UpdateComponentCommand : ComponentCommand
    {
        public int Id { get; set; }

        public class UpdateComponentCommandHandler : IRequestHandler<UpdateComponentCommand, IResult>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;
            private readonly IComponentMapService _componentService;

            public UpdateComponentCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IComponentMapService componentService)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
                _componentService = componentService;
            }

            public async Task<IResult> Handle(UpdateComponentCommand request, CancellationToken cancellationToken)
            {
                var result = OperationResult.CreateBuilder();
                var repository = _unitOfWork.Repository<Component>();

                var entity = await repository.GetByIdAsync(request.Id);
                entity.UpdateAt = DateTime.Now;

                await _componentService.ComponentMappingAsync(request, entity);

                try
                {
                    await repository.UpdateEntity(entity, entity.Id);
                    await _unitOfWork.SaveChangeAsync(cancellationToken);
                }
                catch (Exception ex)
                {
                    result.AppendError(ex.Message);
                }

                return result.BuildResult();
            }
            
        }
    }
}
