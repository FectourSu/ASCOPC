﻿using ASCOPC.Domain.Common;

namespace ASCOPC.Domain.Entities
{
    public class Component : EntityBase
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string? UrlImage { get; set; }
        public string? Feture { get; set; }
        public bool InStock { get; set; }
        public float? Rating { get; set; }
        public string? Desciption {  get; set; } 
        public int Code { get; set; }
        public int ManufacturerId { get; set; }
        public virtual Manufacturer Manufacturer { get; set; }
        public int TypeId { get; set; }
        public virtual ComponentType Type{ get; set; }
        public ICollection<SpecificationComponent> Specifications { get; set; } 
    }
}
