using Blazored.LocalStorage;
using SistemaGestaoClinicaMedica.Apresentacao.Site.Modelo;
using System.Threading.Tasks;

namespace SistemaGestaoClinicaMedica.Apresentacao.Site.Extensions
{
    public static class LocalStorageExtension
    {
        public async static Task CriaConsultaLocalStorageAsync(this ILocalStorageService localStorage, ConsultaLocalStorage consultaLocalStorage)
        {
            await localStorage.SetItemAsync(nameof(ConsultaLocalStorage), consultaLocalStorage);
        }

        public async static Task<ConsultaLocalStorage> ObterConsultaLocalStorageAsync(this ILocalStorageService localStorage)
        {
            var consultaLocalStorage = await localStorage.GetItemAsync<ConsultaLocalStorage>(nameof(ConsultaLocalStorage));
            await localStorage.RemoveItemAsync(nameof(ConsultaLocalStorage));

            return consultaLocalStorage;
        }
    }
}
