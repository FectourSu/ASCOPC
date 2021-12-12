using ASCOPC.Infrastructure.Data.Enums;
using ASCOPC.Shared.DTO;

namespace ASOPC.Application.Features.Builds.Queries.Get
{
    public class GetBuildResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Category Categories { get; set; }
        public virtual ICollection<ComponentsDTO>? Components { get; set; }
    }
}
