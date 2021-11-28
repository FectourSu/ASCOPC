namespace ASCOPC.Client.Service.Interfaces
{
    public interface IBuildModalService
    {
        event Action Update;

        bool? IsOpen { get; set; }

        void Click();
    }
}
