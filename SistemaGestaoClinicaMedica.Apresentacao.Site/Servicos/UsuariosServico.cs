using SistemaGestaoClinicaMedica.Aplicacao.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;

namespace SistemaGestaoClinicaMedica.Apresentacao.Site.Servicos
{
    public class UsuariosServico : ServicoBase<UsuarioDTO, Guid>, IUsuariosServico
    {
        public UsuariosServico(ApplicationState applicationState) : base(applicationState) { }

        public async Task<List<UsuarioDTO>> GetTudoComFiltrosAsync(string busca, bool ativo = true)
        {
            var response = await ApplicationState.HttpClient.GetStringAsync($"{ApiEndPoint}/?busca={busca}&ativo={ativo}");
            return JsonToDTO<List<UsuarioDTO>>(response);
        }

        public async Task<UsuarioDTO> GetPorEmailAsync(string email)
        {
            var response = await ApplicationState.HttpClient.GetStringAsync($"{ApiEndPoint}/por-email/{HttpUtility.UrlEncode(email)}");
            return JsonToDTO<UsuarioDTO>(response);
        }
    }
}
