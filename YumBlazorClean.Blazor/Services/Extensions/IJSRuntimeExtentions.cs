using Microsoft.JSInterop;

namespace YumBlazorClean.Blazor.Services.Extensions
{
    public static class IJSRuntimeExtentions
    {
        public static async Task ToasterSuccess(this IJSRuntime jsRuntime, string message)
        {
            await jsRuntime.InvokeVoidAsync("ShowToaster", "success", message);
        }
        public static async Task ToasterError(this IJSRuntime jsRuntime, string message)
        {
            await jsRuntime.InvokeVoidAsync("ShowToaster", "error", message);
        }
    }
}
