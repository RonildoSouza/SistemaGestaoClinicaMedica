using SistemaGestaoClinicaMedica.Aplicacao.DTO.Login;
using System.Threading.Tasks;

namespace SistemaGestaoClinicaMedica.Apresentacao.Site.Servicos
{
    public interface ILoginServico
    {
        Task<LoginSaidaDTO> LoginAsync(LoginEntradaDTO loginEntrada);
        void Logout();
    }
}
