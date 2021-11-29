using ASCOPC.Client.Service.Interfaces;
using Blazored.Modal;
using Microsoft.AspNetCore.Components;

namespace ASCOPC.Client.Shared.Modals
{
    public partial class BuildsModal
    {
        [Inject]
        private IBuildModalService modal { get; set; }

        private string cssClassShow = string.Empty;

        protected override void OnInitialized()
        {
            modal.Update += Update;
        }

        public async void Update()
        {

            if (modal.IsOpen.Value)
                cssClassShow = string.Empty;
            else
                cssClassShow = "show";

            await InvokeAsync(StateHasChanged);
        }
    }
}
