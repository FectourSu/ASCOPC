using ASCOPC.Domain.Contracts;
using ASCOPC.Shared.DTO;
using MediatR;

namespace ASOPC.Application.Features.Components.Commands.Update
{
    public class UpdateComponentCommand : IRequest<IResult>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string UrlImage { get; set; }
        public bool InStock { get; set; }
        public decimal Rating { get; set; }
        public string Desciption { get; set; }
        public int Code { get; set; }
        public string Manufacturer { get; set; }
        public string Type { get; set; }
        public virtual ICollection<SpecificationsDTO> Specification { get; set; }

        public class UpdateComponentCommandHandler : IRequestHandler<UpdateComponentCommand, IResult>
        {
            public Task<IResult> Handle(UpdateComponentCommand request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }
    }
}
