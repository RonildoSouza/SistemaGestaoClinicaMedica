using SistemaGestaoClinicaMedica.Aplicacao.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;

namespace SistemaGestaoClinicaMedica.Apresentacao.Site.Servicos
{
    public class MedicosServico : ServicoBase<MedicoDTO, Guid>, IMedicosServico
    {
        public MedicosServico(ApplicationState applicationState) : base(applicationState) { }

        public async Task<MedicoDTO> GetPorCRMAsync(string crm)
        {
            var response = await ApplicationState.HttpClient.GetStringAsync($"{ApiEndPoint}/por-crm/{HttpUtility.UrlEncode(crm)}");
            return JsonToDTO<MedicoDTO>(response);
        }

        public async Task<List<MedicoDTO>> GetPorEspecialidadeAsync(Guid especialidadeId)
        {
            var response = await ApplicationState.HttpClient.GetStringAsync($"{ApiEndPoint}/por-especialidade/{especialidadeId}");
            return JsonToDTO<List<MedicoDTO>>(response);
        }
    }
}
