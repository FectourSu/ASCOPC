using ASCOPC.Domain.Entities;
using ASCOPC.Shared.DTO;
using ASOPC.Application.Features.Components.Commands;
using ASOPC.Application.Interfaces.Data;
using ASOPC.Application.Interfaces.Services;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace ASCOPC.Infrastructure.Services
{
    public class ComponentMapService : IComponentMapService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ComponentMapService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task ComponentMappingAsync(ComponentCommand request, Component entity)
        {
            _mapper.Map(request, entity);
            entity.CreateAt = DateTime.Now;

            entity.ManufacturerId = (await GetManufacturerAsync(request.Manufacturer)).Id;
            entity.TypeId = (await GetComponentTypeAsync(request.Type)).Id;
            entity.SpecificationComponent = await GetSpecificationComponentAsync(entity, request.Specification);
        }

        public async Task<IEnumerable<Component>> FilterComponentsBySpecifications(IQueryable<Component> entities, 
            IEnumerable<Specifications> request)
        {
            if (!request?.Any() ?? true)
                return entities.AsEnumerable();

            var repository = await _unitOfWork.Repository<SpecificationComponent>().GetAllAsync();

            IEnumerable<SpecificationComponent> specifications = null;
            
            foreach (var spec in request)
            {
                specifications = repository.Where(
                s => s.Specifications.SpecificationTitle.ToLower() == spec.SpecificationTitle.ToLower() &&
                     s.Specifications.SpecificationValue.ToLower() == spec.SpecificationValue.ToLower()
                );
            }

            var result = specifications.Select(s => s.Component);

            return result;
        }



        public async Task<ComponentType> GetComponentTypeAsync(string type)
        {
            var repository = _unitOfWork.Repository<ComponentType>();
            var entities = await repository.GetAllAsync();
            var entity = entities.SingleOrDefault(x => x.Name.ToLower() == type.ToLower());

            if (entity is null)
            {
                entity = await repository.AddEntity(new ComponentType
                {
                    Name = type,
                    CreateAt = DateTime.Now,
                });

                _unitOfWork.SaveChanges();
            }

            return entity;
        }

        public async Task<Manufacturer> GetManufacturerAsync(string manufacturer)
        {
            var repository = _unitOfWork.Repository<Manufacturer>();
            var entities = await repository.GetAllAsync();
            var entity = entities.SingleOrDefault(x => x.Name.ToLower() == manufacturer.ToLower());

            if (entity is null)
            {
                entity = await repository.AddEntity(new Manufacturer
                {
                    Name = manufacturer,
                    CreateAt = DateTime.Now,
                });

                _unitOfWork.SaveChanges();
            }
            return entity;
        }

        public async Task<ICollection<SpecificationComponent>> GetSpecificationComponentAsync(
            Component componentEntity, ICollection<SpecificationsDTO> specifications)
        {
            var specificationComponents = new List<SpecificationComponent>();

            var repository = _unitOfWork.Repository<SpecificationComponent>();
            var repositorySpecification = _unitOfWork.Repository<Specifications>();

            foreach (var specification in specifications)
            {
                var specificationEntity = (await repositorySpecification.GetAllAsync())
                    .SingleOrDefault(entity =>
                        entity.SpecificationTitle.ToLower() == specification.SpecificationTitle.ToLower() &&
                        entity.SpecificationValue.ToLower() == specification.SpecificationValue.ToLower());

                if (specificationEntity is null)
                {
                    specificationEntity = await repositorySpecification.AddEntity(new Specifications
                    {
                        SpecificationValue = specification.SpecificationValue,
                        SpecificationTitle = specification.SpecificationTitle,
                        CreateAt = DateTime.Now
                    });

                    _unitOfWork.SaveChanges();
                }

                specificationComponents.Add(new SpecificationComponent
                {
                    ComponentId = componentEntity.Id,
                    SpecificationId = specificationEntity.Id
                });
            }

            return specificationComponents;
        }

        public async Task<bool> TryUpdateAsync(Component component)
        {
            var repository = _unitOfWork.Repository<Component>();
            var entities = await repository.GetAllAsync();
            var entity = entities.SingleOrDefault(c => c.Name.ToLower() == component.Name.ToLower());

            if (entity is null) return false;

            _mapper.Map(component, entity);
            entity.UpdateAt = DateTime.Now;

            try
            {
                await repository.UpdateEntity(entity, entity.Id);
                _unitOfWork.SaveChanges();
            }
            catch
            {
                return false;
            }

            return true;
        }
    }
}
