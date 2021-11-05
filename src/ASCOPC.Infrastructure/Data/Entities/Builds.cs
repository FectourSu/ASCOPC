using ASCOPC.Domain.Common;
using ASCOPC.Domain.Entities;

namespace ASCOPC.Infrastructure.Data.Entities
{
    public class Builds : EntityBase
    {
        public string? Name { get; set; }
        public Category Categories { get; set; }
        public decimal Price { get; set; }
        public virtual ICollection<UserBuilds> UserBuilds { get; set; }
        public virtual ICollection<Component> Components { get; set; }
    }
}
