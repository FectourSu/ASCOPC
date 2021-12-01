using ASCOPC.Domain.Contracts;
using ASCOPC.Domain.Interfaces;
using ASCOPC.Infrastructure.Data.Entities;
using ASCOPC.Shared;
using ASCOPC.Shared.DTO;
using ASOPC.Application.Interfaces.Data;
using ASOPC.Application.Interfaces.Services;
using AutoMapper;

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
        public async Task<IResult> UpdateAsync(BuildsDTO build, int id)
        {
            var result = OperationResult.CreateBuilder();

            var entity = _mapper.Map<Builds>(build);
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
                result.AppendError($"{entity} is null");

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
        public Task<IResult> InsertAsync(BuildsDTO build)
        {
            var result = OperationResult.CreateBuilder();

            if (build is null)
                result.AppendError($"Build is empty");

            var entity = _mapper.Map<Builds>(build);
            entity.CreateAt = DateTime.Now;

            _repository.AddEntity(entity);

            _unitOfWork.SaveChanges();

            return Task.FromResult(result.BuildResult());
        }
    }
}
