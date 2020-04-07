using Blazored.LocalStorage;
using SistemaGestaoClinicaMedica.Apresentacao.Site.Modelo;
using SistemaGestaoClinicaMedica.Apresentacao.Site.Pages;
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

            if (consultaLocalStorage != null)
                await localStorage.RemoveItemAsync(nameof(ConsultaLocalStorage));

            return consultaLocalStorage;
        }

        public async static Task CriaUsuarioCargoIdEdicaoLocalStorageAsync(this ILocalStorageService localStorage, string cargoId)
        {
            await localStorage.SetItemAsync(nameof(UsuariosForm), cargoId);
        }

        public async static Task<string> ObterUsuarioCargoIdEdicaoLocalStorageAsync(this ILocalStorageService localStorage)
        {
            var cargoId = await localStorage.GetItemAsync<string>(nameof(UsuariosForm));

            if (cargoId != null)
                await localStorage.RemoveItemAsync(nameof(UsuariosForm));

            return cargoId;
        }
    }
}
