using ASCOPC.Infrastructure.Data.Enums;

namespace ASCOPC.Shared.DTO
{
    public class BuildsComponentsDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Guid UserId { get; set; }
        public Category Categories { get; set; }
        public IEnumerable<int> ComponentsIds { get; set; }
    }
}
