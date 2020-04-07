using SistemaGestaoClinicaMedica.Aplicacao.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaGestaoClinicaMedica.Apresentacao.Site.Servicos
{
    public class PacientesServico : ServicoBase<PacienteDTO, Guid>, IPacientesServico
    {
        public PacientesServico(ApplicationState applicationState) : base(applicationState) { }

        public async Task<PacienteDTO> GetPorCodigoOuCPFAsync(string codigoOuCpf)
        {
            var response = await ApplicationState.HttpClient.GetStringAsync($"{ApiEndPoint}/por-codigo-ou-cpf/{codigoOuCpf}");
            return JsonToDTO<PacienteDTO>(response);
        }

        public async Task<List<PacienteDTO>> GetTudoComFiltrosAsync(string busca, bool ativo = true)
        {
            var response = await ApplicationState.HttpClient.GetStringAsync($"{ApiEndPoint}/?busca={busca}&ativo={ativo}");
            return JsonToDTO<List<PacienteDTO>>(response);
        }
    }
}
