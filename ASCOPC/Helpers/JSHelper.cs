using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
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
