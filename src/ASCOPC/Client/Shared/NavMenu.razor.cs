using Blazored.Modal;
using Blazored.Modal.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace ASCOPC.Client.Shared
{
    partial class NavMenu
    {
        public class MainModal
        {
            public IModalService Modal { get; set; }

            public MainModal(IModalService modal)
            {
                Modal = modal;
            }

            public async virtual Task<IModalReference> CreateAsync<T>()
                where T : IComponent
            {
                var options = new ModalOptions()
                {
                    Animation = ModalAnimation.FadeIn(0.18)
                };

                return await Task.FromResult(Modal.Show<T>("", options));
            }
        }
        public class BlurModal : MainModal
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
}
