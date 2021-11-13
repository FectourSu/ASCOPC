using ASCOPC.Domain.Common;
using ASCOPC.Domain.Entities;
using ASCOPC.Infrastructure.Data.Enums;

namespace ASCOPC.Infrastructure.Data.Entities
{
    public class Builds : EntityBase
    {
        public string Name { get; set; }
        public string Index { get; set; }
        public Category Categories { get; set; }
        public decimal Price { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Component> Components { get; set; }
    }
}
