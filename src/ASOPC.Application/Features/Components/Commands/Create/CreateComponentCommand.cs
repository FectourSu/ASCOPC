using ASCOPC.Domain.Contracts;
using ASCOPC.Domain.Entities;
using ASCOPC.Shared.DTO;
using AutoMapper;
using MediatR;

namespace ASOPC.Application.Features.Components.Commands.Create
{
    public class CreateComponentCommand : IRequest<IResult>
    {
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

        public class CreateComponentsHandler : IRequestHandler<CreateComponentCommand, IResult>
        {
            private readonly IMapper _mapper;
            //private readonly IUnitOfWork _unitOfWork;
            public Task<IResult> Handle(CreateComponentCommand request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }
    }
}
