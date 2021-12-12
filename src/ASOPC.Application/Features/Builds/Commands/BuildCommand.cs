using ASCOPC.Domain.Contracts;
using ASCOPC.Infrastructure.Data.Enums;
using ASCOPC.Shared.DTO;
using MediatR;

namespace ASOPC.Application.Features.Builds.Commands
{
    public class BuildCommand : IRequest<IResult>
    {
        public string Name { get; set; }
        public string? UserId { get; set; }
        public Category Categories { get; set; }
        public IEnumerable<int>? ComponentsIds { get; set; }
    }
}
