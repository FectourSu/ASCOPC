using ASCOPC.Domain.Contracts;
using ASCOPC.Domain.Interfaces;
using ASCOPC.Infrastructure.Data.Entities;
using ASCOPC.Shared;
using ASCOPC.Shared.DTO;
using ASOPC.Application.Interfaces.Data;
using ASOPC.Application.Interfaces.Services;
using AutoMapper;
using ASCOPC.Domain.Entities;
using ASCOPC.Infrastructure.Entities;

namespace ASCOPC.Infrastructure.Services
{
    public class BuildsService : IBuildsService
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryAsync<Builds> _repository;
        private readonly IUnitOfWork _unitOfWork;

        // TODO: remove dependency
        private IRepositoryAsync<Component> _repoComponent => _unitOfWork.Repository<Component>();

        public BuildsService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _repository = _unitOfWork.Repository<Builds>();
        }

        public async Task<IResult> DeleteAsync(int id)
        {
            var result = OperationResult.CreateBuilder();

            var entity = await _repository.GetByIdAsync(id);

            if (entity is null)
                return result.AppendError($"{entity} is null")
                    .BuildResult();

            await _repository.DeleteEntity(entity);
            _unitOfWork.SaveChanges();

            return result.BuildResult();
        }

        public async Task<IResult> UpdateAsync(BuildsComponentsDTO build, int id)
        {
            var result = OperationResult.CreateBuilder();

            if (build is null)
               return result.AppendError($"{build} is empty")
                    .BuildResult();

            var entity = _mapper.Map<Builds>(build);
            var entitybuild = _mapper.Map<BuildsComponent>(build);

            entitybuild.Components = await GetComponentsByBuilds(build);
            entity.UpdateAt = DateTime.Now;

            await _repository.UpdateEntity(entity, id);
            _unitOfWork.SaveChanges();

            return result.BuildResult();
        }

        public async Task<IResult<IEnumerable<BuildsDTO>>> GetAllAsync()
        {
            var result = OperationResult<IEnumerable<BuildsDTO>>.CreateBuilder();
            var entity = _mapper.Map<IEnumerable<BuildsDTO>>(await _repository.GetAllAsync());

            if (entity is null)
                return result.AppendError($"{entity} is null")
                    .BuildResult();

            return result.SetValue(entity).BuildResult();
        }

        public async Task<IResult<BuildsDTO>> GetAsync(int id)
        {
            var result = OperationResult<BuildsDTO>.CreateBuilder();
            var entity = _mapper.Map<BuildsDTO>(await _repository.GetByIdAsync(id));

            if (entity is null)
                result.AppendError($"{entity} is null");

            return result.SetValue(entity).BuildResult();
        }

        private async Task<ICollection<Component>> GetComponentsByBuilds(BuildsComponentsDTO build)
        {
            List<Component> components = new();

            foreach (var componentId in build.ComponentsIds)
            {
                var component = await _repoComponent.GetByIdAsync(componentId);

                if (component is not null)
                    components.Add(component);
            }

            return components;
        }
  

        public async Task<IResult> InsertAsync(BuildsComponentsDTO build)
        {           
            var result = OperationResult.CreateBuilder();

            if (build is null)
                return result.AppendError($"{build} is empty")
                    .BuildResult();

            var entity = _mapper.Map<Builds>(build);
            var entitybuilds = _mapper.Map<BuildsComponent>(build);

            entitybuilds.Components = await GetComponentsByBuilds(build);
            entitybuilds.Builds = entity;
 
            entity.CreateAt = DateTime.Now;
            
            await _repository.AddEntity(entity);

            _unitOfWork.SaveChanges();

            return result.BuildResult();
        }
    }
}
