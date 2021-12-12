namespace ASCOPC.Shared.DTO
{
    public class ComponentsDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string? UrlImage { get; set; }
        public bool InStock { get; set; }
        public decimal? Rating { get; set; }
        public string? Description { get; set; }
        public int Code { get; set; }
        public string Manufacturer { get; set; }
        public string Type { get; set; }
        public ICollection<SpecificationsDTO> Specification { get; set; }
    }
}
