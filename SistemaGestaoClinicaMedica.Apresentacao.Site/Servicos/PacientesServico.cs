using SistemaGestaoClinicaMedica.Aplicacao.DTO;
using System;
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
    }
}
