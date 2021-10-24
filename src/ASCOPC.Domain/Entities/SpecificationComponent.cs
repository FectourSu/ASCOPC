using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASCOPC.Domain.Entities
{
    public class SpecificationComponent
    {
        public int SpecificationId { get; set; }
        public virtual Specifications Specifications { get; set; }
        public int ComponentId { get; set; }
        public virtual Component Component { get; set; }
    }
}
