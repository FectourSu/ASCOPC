using ASCOPC.Shared.DTO;

namespace ASOPC.Application.Features.Components.Queries.Get
{
    public class GetComponentResponse
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string UrlImage { get; set; }
        public bool InStock { get; set; }
        public decimal Rating { get; set; }
        public string Desciption { get; set; }
        public string Manufacturer { get; set; }
        public string Type { get; set; }
        public virtual ICollection<SpecificationsDTO> Specification { get; set; }
    }
}
