using ASCOPC.Domain.Entities;
using ASCOPC.Infrastructure.Data;
using ASOPC.Application.Interfaces.Data;

namespace ASCOPC.Infrastructure.Repositories
{
    public class SpecificationRepository : RepositoryAsync<Specifications, int>, ISpecificationRepository
    {
        public SpecificationRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<Specifications> Get(string type, string name)
        {
            return (await GetAllAsync())
                .SingleOrDefault(entity => entity.SpecificationTitle.ToLower() == name.ToLower()
                    && entity.SpecificationValue.ToLower() == type.ToLower());
        }

        public async Task<IEnumerable<Specifications>> Get(IEnumerable<(string type, string name)> props)
        {
            var list = new List<Specifications>();

            foreach (var item in props)
            {
                var entity = await Get(item.type, item.name);

                if (entity == null)
                    throw new Exception($"The specified parameter was not found: {item.type}, {item.name}");

                list.Add(entity);
            }

            return list;
        }
    }
}
