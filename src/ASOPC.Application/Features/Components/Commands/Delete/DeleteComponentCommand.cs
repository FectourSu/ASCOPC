using ASCOPC.Domain.Contracts;
using ASCOPC.Domain.Entities;
using ASCOPC.Shared;
using ASOPC.Application.Interfaces.Data;
using AutoMapper;
using MediatR;

namespace ASOPC.Application.Features.Components.Commands.Delete
{
    public class DeleteComponentCommand : IRequest<IResult>
    {
        public int Id { get; set; }

        public class DeleteComponentCommandHandler : IRequestHandler<DeleteComponentCommand, IResult>
        {
            private readonly IUnitOfWork unitOfWork;

            public DeleteComponentCommandHandler(IUnitOfWork unitOfWork)
            {
                this.unitOfWork = unitOfWork;
            }

            public async Task<IResult> Handle(DeleteComponentCommand request, CancellationToken cancellationToken)
            {
                var result = OperationResult.CreateBuilder();
                var repository = unitOfWork.Repository<Component>();
                var entity = await repository.GetByIdAsync(request.Id);

                if (entity is null)
                    return result.AppendError($"Couldn't find the component by id: {request.Id}")
                        .BuildResult();

                try
                {
                    await repository.DeleteEntity(entity);
                    await unitOfWork.SaveChangeAsync(cancellationToken);
                }
                catch (Exception ex)
                {
                    result.AppendError(ex.Message)
                          .AppendError(ex.InnerException?.Message);
                }

                return result.BuildResult();
            }
        }
    }
}
