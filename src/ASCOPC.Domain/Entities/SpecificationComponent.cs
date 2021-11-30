namespace ASCOPC.Domain.Entities
{
    public class SpecificationComponent
    {
        public int SpecificationId { get; set; }
        public Specifications Specifications { get; set; }
        public int ComponentId { get; set; }
        public Component Component { get; set; }
    }
}
