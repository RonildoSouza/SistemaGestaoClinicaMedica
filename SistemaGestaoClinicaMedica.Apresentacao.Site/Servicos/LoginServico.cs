using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using SistemaGestaoClinicaMedica.Aplicacao.DTO.Login;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestaoClinicaMedica.Apresentacao.Site.Servicos
{
    public class LoginServico : ILoginServico
    {
        private readonly AuthenticationStateProvider _authenticationStateProvider;
        private readonly ILocalStorageService _localStorage;
        public const string ChaveLocalStorage = "authToken";
        private readonly Uri _requestUri;

        public LoginServico(IConfiguration configuration, AuthenticationStateProvider authenticationStateProvider, ILocalStorageService localStorage)
        {
            var apiUrlBase = configuration.GetValue<string>("ApiUrlBase");
            Uri.TryCreate($"{apiUrlBase}/login", UriKind.Absolute, out _requestUri);

            _authenticationStateProvider = authenticationStateProvider;
            _localStorage = localStorage;
        }

        public async Task<HttpResponseMessage> Login(LoginEntradaDTO loginEntrada)
        {
            var jsonString = JsonConvert.SerializeObject(loginEntrada);
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            var response = await new HttpClient().PostAsync(_requestUri, content);

            if (response.IsSuccessStatusCode)
            {
                var loginSaida = JsonConvert.DeserializeObject<LoginSaidaDTO>(await response.Content.ReadAsStringAsync());

                await _localStorage.SetItemAsync(ChaveLocalStorage, loginSaida.TokenDeAcesso);
                CustomAuthenticationStateProvider.SetaTokenJwt(loginSaida.TokenDeAcesso);
                ((CustomAuthenticationStateProvider)_authenticationStateProvider).SetaUsuarioComoAutenticado(loginEntrada.Email);
            }

            return response;
        }

        public async Task Logout()
        {
            await _localStorage.RemoveItemAsync(ChaveLocalStorage);
            CustomAuthenticationStateProvider.SetaTokenJwt(string.Empty);
            ((CustomAuthenticationStateProvider)_authenticationStateProvider).SetaUsuarioComoNaoAutenticado();
        }
    }
}
