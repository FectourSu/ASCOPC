using ASCOPC.Client.Service.Interfaces;

namespace ASCOPC.Client.Service
{
    public class BuildModalService : IBuildModalService
    {
        public event Action Update;

        public bool? IsOpen { get; set; } = false;
        public void Click()
        {
            Update?.Invoke();

            IsOpen = !IsOpen;
        }
    }
}
