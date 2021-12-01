using ASCOPC.Domain.Common;
using ASCOPC.Domain.Entities;
using ASCOPC.Infrastructure.Data.Enums;

namespace ASCOPC.Infrastructure.Data.Entities
{
    public class Builds : EntityBase
    {
        public string Name { get; set; }
        public Category Categories { get; set; }
        public virtual User User { get; set; }
        public string UserId { get; set; }
        public virtual ICollection<Component> Components { get; set; }
    }
}
