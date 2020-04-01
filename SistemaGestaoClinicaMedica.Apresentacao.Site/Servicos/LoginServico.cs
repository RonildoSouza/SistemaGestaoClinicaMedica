using Newtonsoft.Json;
using SistemaGestaoClinicaMedica.Aplicacao.DTO.Login;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestaoClinicaMedica.Apresentacao.Site.Servicos
{
    public class LoginServico : ILoginServico
    {
        private readonly ApplicationState _applicationState;
        public const string ChaveLocalStorage = "access_token";

        public LoginServico(ApplicationState applicationState)
        {
            _applicationState = applicationState;
        }

        public async Task<LoginSaidaDTO> LoginAsync(LoginEntradaDTO loginEntrada)
        {
            var jsonString = JsonConvert.SerializeObject(loginEntrada);
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            var response = await _applicationState.HttpClient.PostAsync("/api/login", content);

            if (!response.IsSuccessStatusCode)
                return null;

            var loginSaida = JsonConvert.DeserializeObject<LoginSaidaDTO>(await response.Content.ReadAsStringAsync());
            _applicationState.Token = loginSaida.Token;
            _applicationState.HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", loginSaida.Token);

            return loginSaida;
        }

        public void Logout()
        {
            _applicationState.Token = null;
            _applicationState.HttpClient.DefaultRequestHeaders.Authorization = null;
        }
    }
}
