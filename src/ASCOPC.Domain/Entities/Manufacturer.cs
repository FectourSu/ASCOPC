using ASCOPC.Domain.Common;

namespace ASCOPC.Domain.Entities
{
    public class Manufacturer : EntityBase
    {
        public string Name { get; set; }
        public ICollection<Component> Components { get; set; }
    }
}
