using ASCOPC.Infrastructure.Data.Enums;

namespace ASCOPC.Shared.DTO
{
    public class BuildsDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Category Categories { get; set; }
        public virtual ICollection<ComponentsDTO> Components { get; set; }
    }
}
