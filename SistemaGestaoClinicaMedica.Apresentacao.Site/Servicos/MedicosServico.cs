using SistemaGestaoClinicaMedica.Aplicacao.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaGestaoClinicaMedica.Apresentacao.Site.Servicos
{
    public class MedicosServico : ServicoBase<MedicoDTO, Guid>, IMedicosServico
    {
        public MedicosServico(ApplicationState applicationState) : base(applicationState) { }

        public async Task<List<MedicoDTO>> GetPorEspecialidadeAsync(Guid especialidadeId)
        {
            var response = await ApplicationState.HttpClient.GetStringAsync($"{ApiEndPoint}/por-especialidade/{especialidadeId}");
            return JsonToDTO<List<MedicoDTO>>(response);
        }
    }
}
