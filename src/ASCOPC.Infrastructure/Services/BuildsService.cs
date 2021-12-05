using ASCOPC.Domain.Contracts;
using ASCOPC.Domain.Entities;
using ASCOPC.Domain.Interfaces;
using ASCOPC.Infrastructure.Data.Entities;
using ASCOPC.Infrastructure.Entities;
using ASCOPC.Shared;
using ASCOPC.Shared.DTO;
using ASOPC.Application.Interfaces.Data;
using ASOPC.Application.Interfaces.Services;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace ASCOPC.Infrastructure.Services
{
    public class BuildsService : IBuildsService
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryAsync<Builds> _repository;
        private readonly IUnitOfWork _unitOfWork;
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

        public async Task<IResult> UpdateAsync(BuildsComponentsDTO build)
        {
            var result = OperationResult.CreateBuilder();

            if (build is null)
                return result.AppendError($"{build} is empty")
                     .BuildResult();

            var components = await _unitOfWork.Repository<ComponentBuilds>()
                .GetAllAsync();

            foreach (var builds in components.Where(u => u.BuildId == build.Id))
                await _unitOfWork.Repository<ComponentBuilds>()
                    .DeleteEntity(builds);

            var entity = await _repository.GetByIdAsync(build.Id);
            entity.UpdateAt = DateTime.Now;
            entity.Name = build.Name;
            entity.Categories = build.Categories;

            foreach (var component in await GetComponentsByBuilds(build))
                await _unitOfWork.Repository<ComponentBuilds>()
                    .AddEntity(new(entity, component));

            await _repository.UpdateEntity(entity, entity.Id);
            _unitOfWork.SaveChanges();

            return result.BuildResult();
        }

        public async Task<IResult<IEnumerable<BuildsDTO>>> GetAllAsync()
        {
            var result = OperationResult<IEnumerable<BuildsDTO>>.CreateBuilder();

            var builds = await _repository.GetAllAsync();
            var comBuilds = await _unitOfWork.Repository<ComponentBuilds>().GetAllAsync();

            var entity = builds.Select(s => new BuildsDTO()
            {
                Id = s.Id,
                Components = _mapper.Map<ICollection<ComponentsDTO>>(comBuilds
                    .Where(b => b.BuildId == s.Id)
                    .Select(s => s.Components)),
                Name = s.Name,
                Categories = s.Categories
            });

            if (entity is null)
                return result.AppendError($"{entity} is null")
                    .BuildResult();

            return result.SetValue(entity).BuildResult();
        }

        public async Task<IResult<BuildsDTO>> GetAsync(int id)
        {
            var result = OperationResult<BuildsDTO>.CreateBuilder();

            var builds = await _repository.GetByIdAsync(id);
            var comBuilds = await _unitOfWork.Repository<ComponentBuilds>().GetAllAsync();

            var entity = new BuildsDTO()
            {
                Id = builds.Id,
                Components = _mapper.Map<ICollection<ComponentsDTO>>(comBuilds
                    .Where(b => b.BuildId == builds.Id)
                    .Select(s => s.Components)),
                Name = builds.Name,
                Categories = builds.Categories
            };

            if (entity is null)
                return result.AppendError($"{entity} is null")
                    .BuildResult();

            return result.SetValue(entity).BuildResult();
        }

        public async Task<IResult<IEnumerable<BuildsDTO>>> GetUserBuildAsync(string userId)
        {
            var result = OperationResult<IEnumerable<BuildsDTO>>.CreateBuilder();

            var userBuilds = _unitOfWork.Repository<UserBuilds>().Entities
                .Include(ub => ub.Build)
                .ThenInclude(b => b.ComponentBuilds)
                .Where(ub => ub.UserId == userId)
                .Select(ub => ub.Build);

            var dto = userBuilds.Select(b => new BuildsDTO
            {
                Id = b.Id,
                Name = b.Name,
                Categories = b.Categories,
                Components = _mapper.Map<ICollection<ComponentsDTO>>(b.ComponentBuilds.Select(a => a.Components))
            });

            return result.SetValue(dto).BuildResult();
        }

        private async Task<ICollection<Component>> GetComponentsByBuilds(BuildsComponentsDTO build)
        {
            List<Component> components = new();
            var componentRepository = _unitOfWork.Repository<Component>();

            foreach (var componentId in build.ComponentsIds)
            {
                var component = await componentRepository.GetByIdAsync(componentId);

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

            var user = await _unitOfWork.Repository<User>()
                .GetByIdAsync(build.UserId);

            var entity = _mapper.Map<Builds>(build);
            entity.CreateAt = DateTime.Now;

            foreach (var component in await GetComponentsByBuilds(build))
                await _unitOfWork.Repository<ComponentBuilds>()
                    .AddEntity(new(entity, component));

            await _unitOfWork.Repository<UserBuilds>()
                .AddEntity(new UserBuilds(user, entity));

            await _repository.AddEntity(entity);
            _unitOfWork.SaveChanges();

            return result.BuildResult();
        }
    }
}
