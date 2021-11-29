using ASCOPC.Domain.Entities;
using ASCOPC.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASOPC.Application.Interfaces.Data
{
    public interface ISpecificationRepository : IRepositoryAsync<Specifications>
    {
        Task<Specifications> Get(string type, string name);
        Task<IEnumerable<Specifications>> Get(IEnumerable<(string type, string name)> props);
    }
}
