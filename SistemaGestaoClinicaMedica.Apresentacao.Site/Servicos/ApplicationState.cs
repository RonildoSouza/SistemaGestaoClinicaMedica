using System.Net.Http;

namespace SistemaGestaoClinicaMedica.Apresentacao.Site.Servicos
{
    public class ApplicationState
    {
        public ApplicationState(HttpClient httpClient)
        {
            HttpClient = httpClient;
        }

        public HttpClient HttpClient { get; }
        public string Token { get; set; }
    }
}
