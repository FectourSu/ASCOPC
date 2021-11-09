using System.IO;
using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace ASCOPC.Helpers
{
    public static class JSHelper
    {
        public static async Task Scroll(this IJSRuntime jSRuntime, string id)
        {
            await jSRuntime.InvokeVoidAsync("blazorScrollToElementId", id);
        }
    }
}