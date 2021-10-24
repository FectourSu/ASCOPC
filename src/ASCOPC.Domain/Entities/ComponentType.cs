using ASCOPC.Domain.Common;

namespace ASCOPC.Domain.Entities
{
    public class ComponentType : EntityBase
    {
        public string Name { get; set; }
        public ICollection<Component> Components { get; set; }
    }
}
