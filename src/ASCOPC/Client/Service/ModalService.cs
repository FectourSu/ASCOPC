using ASCOPC.Client.Service.Interfaces;
using Blazored.Modal;
using Blazored.Modal.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace ASCOPC.Client.Service
{
    public class MainModal : IMyModalService
    {
        public IModalService Modal { get; set; }

        public MainModal(IModalService modal)
        {
            Modal = modal;
        }
        public ModalResult? Result { get; private set; }

        public async virtual Task<IModalReference> CreateAsync<T>()
            where T : IComponent
        {
            var options = new ModalOptions()
            {
                Animation = ModalAnimation.FadeIn(0.18)
            };

            var modal = Modal.Show<T>("", options);
            Result = await modal.Result;

            return await Task.FromResult(modal);
        }
    }
    public class BlurModal : MainModal, IMyModalService
    {
        public IJSRuntime Js;
        public MainModal Main { get; }

        public BlurModal(MainModal main, IJSRuntime js) : base(main.Modal)
        {
            Main = main;
            Js = js;
        }

        public async override Task<IModalReference> CreateAsync<T>()
        {
            await Js.InvokeVoidAsync("blazorBlur");

            var modal = await Main.CreateAsync<T>();
            var result = await modal.Result;

            if (result.Cancelled)
                await Js.InvokeVoidAsync("blazorNotBlur");

            return modal;
        }
    }
}
