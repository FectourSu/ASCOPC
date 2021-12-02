using ASCOPC.Domain.Entities;
using ASCOPC.Infrastructure.Data.Entities;

namespace ASCOPC.Infrastructure.Entities
{
    public class BuildsComponent
    {
        public int ComponentId { get; set; }
        public virtual ICollection<Component>? Components { get; set; }
        public int BuildId { get; set; }
        public virtual Builds? Builds { get; set; }

    }
}
