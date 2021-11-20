using ASCOPC.Domain.Contracts;
using ASCOPC.Domain.Entities;
using ASCOPC.Infrastructure.Data.Enums;
using MediatR;

namespace ASOPC.Application.Features.Builds.Commands.Create
{
    public class CreateBuildCommand : IRequest<IResult>
    {
        public string Name { get; set; }
        public Category Categories { get; set; }
        public virtual ICollection<Component> Components { get; set; }
    }
}
