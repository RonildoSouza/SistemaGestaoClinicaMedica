using SistemaGestaoClinicaMedica.Aplicacao.DTO.Login;
using System.Net.Http;
using System.Threading.Tasks;

namespace SistemaGestaoClinicaMedica.Apresentacao.Site.Servicos
{
    public interface ILoginServico
    {
        Task<HttpResponseMessage> Login(LoginEntradaDTO loginEntrada);
        Task Logout();
    }
}
