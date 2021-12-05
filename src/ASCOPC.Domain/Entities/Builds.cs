using ASCOPC.Domain.Common;
using ASCOPC.Infrastructure.Data.Enums;

namespace ASCOPC.Domain.Entities
{
    public class Builds : EntityBase
    {
        public string Name { get; set; }
        public Category Categories { get; set; }
        public virtual ICollection<ComponentBuilds> ComponentBuilds { get; set; }
    }
}
