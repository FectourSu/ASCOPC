using Blazored.Modal;
using Microsoft.AspNetCore.Components;

namespace ASCOPC.Client.Service.Interfaces
{
    public interface IMyModalService
    {
        public Task<IModalReference> CreateAsync<T>()
          where T : IComponent;
    }
}
