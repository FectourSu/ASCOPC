using ASCOPC.Domain.Contracts;
using ASCOPC.Domain.Entities;
using ASCOPC.Domain.Interfaces;
using ASCOPC.Shared;
using ASCOPC.Shared.DTO;
using ASOPC.Application.Features.Components.Commands.Create;
using ASOPC.Application.Interfaces.Data;
using ASOPC.Application.Interfaces.Services;
using AutoMapper;
using MediatR;

namespace ASCOPC.Infrastructure.Services
{
    public class ComponentService //: IComponentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ComponentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task<IResult<ComponentsDTO>> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IResult<ComponentsDTO>> Get(int id)
        {
            throw new NotImplementedException();
        }

        //public Task<IResult<ComponentsDTO>> Insert(ComponentsDTO components)
        //{
            
        //}

        public Task<IResult<ComponentsDTO>> Update(ComponentsDTO components)
        {
            throw new NotImplementedException();
        }

        //private async Task<IResult<ComponentsDTO>> GetOrCreateEntity(IRepositoryAsync<ComponentsDTO> repository, string name)
        //{

        //}
        private async Task MapPropertyRequest(ComponentsDTO components, IEnumerable<SpecificationsDTO> specifications)
        {

        }

    }
}
