using ASCOPC.Domain.Entities;
using ASCOPC.Shared.DTO;
using ASOPC.Application.Features.Components.Commands;

namespace ASOPC.Application.Interfaces.Services
{
    public interface IComponentMapService
    {
        Task<bool> TryUpdateAsync(Component component);
        Task<ComponentType> GetComponentTypeAsync(string type);
        Task<Manufacturer> GetManufacturerAsync(string manufacturer);
        Task ComponentMappingAsync(ComponentCommand request, Component entity);
        Task<ICollection<SpecificationComponent>> GetSpecificationComponentAsync(
                Component componentEntity, ICollection<SpecificationsDTO> specifications);
    }
}
