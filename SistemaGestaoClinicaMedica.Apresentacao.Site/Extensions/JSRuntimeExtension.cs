using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace SistemaGestaoClinicaMedica.Apresentacao.Site.Extensions
{
    public static class JSRuntimeExtension
    {
        public async static Task ScrollToAsync(this IJSRuntime jsRuntime, int xPos = 0, int yPos = 0)
        {
            var options = new
            {
                top = yPos,
                left = xPos,
                behavior = "smooth"
            };

            await jsRuntime.InvokeVoidAsync($"scrollTo", options);
        }

        public async static Task ShowTabFromUrlIdAsync(this IJSRuntime jsRuntime)
        {
            await jsRuntime.InvokeVoidAsync("jsRuntimeExtensionJsInterop.showTabFromUrlId");
        }

        public async static Task ForceReloadAsync(this IJSRuntime jsRuntime)
        {
            await jsRuntime.InvokeVoidAsync("location.reload");
        }

        public async static Task PrintContentAsync(this IJSRuntime jsRuntime, string elementId)
        {
            await jsRuntime.InvokeVoidAsync("jsRuntimeExtensionJsInterop.printContent", elementId);
        }
    }
}
