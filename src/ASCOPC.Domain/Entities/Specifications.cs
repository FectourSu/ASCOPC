using ASCOPC.Domain.Common;

namespace ASCOPC.Domain.Entities
{
    public class Specifications : EntityBase
    {
        public string SpecificationTitle { get; set; }
        public string SpecificationValue { get; set; }
        public ICollection<SpecificationComponent> Components { get; set; }
    }
}
