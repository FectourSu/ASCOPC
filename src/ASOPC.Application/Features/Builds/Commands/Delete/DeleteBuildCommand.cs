using ASCOPC.Domain.Contracts;
using ASCOPC.Domain.Entities;
using ASCOPC.Infrastructure.Data.Enums;
using MediatR;

namespace ASOPC.Application.Features.Builds.Commands.Delete
{
    public class DeleteBuildCommand : IRequest<IResult>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Category Categories { get; set; }
        public decimal Price { get; set; }
        public virtual ICollection<Component> Components { get; set; }
    }
}
