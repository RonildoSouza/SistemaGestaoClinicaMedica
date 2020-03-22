using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace SistemaGestaoClinicaMedica.Apresentacao.Site.Extensions
{
    public static class JSRuntimeExtension
    {
        public async static Task ScrollTo(this IJSRuntime jsRuntime, int xPos = 0, int yPos = 0)
        {
            var options = new
            {
                top = yPos,
                left = xPos,
                behavior = "smooth"
            };

            await jsRuntime.InvokeVoidAsync($"scrollTo", options);
        }
    }
}
