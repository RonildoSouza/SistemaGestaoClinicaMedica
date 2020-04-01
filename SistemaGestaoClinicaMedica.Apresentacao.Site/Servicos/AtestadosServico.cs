using SistemaGestaoClinicaMedica.Aplicacao.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaGestaoClinicaMedica.Apresentacao.Site.Servicos
{
    public class AtestadosServico : ServicoBase<AtestadoDTO, Guid>, IAtestadosServico
    {
        public AtestadosServico(ApplicationState applicationState) : base(applicationState) { }

        public async Task<List<AtestadoDTO>> GetPorConsultaAsync(Guid consultaId)
        {
            var response = await ApplicationState.HttpClient.GetStringAsync($"{ApiEndPoint}/por-consulta/{consultaId}");
            return JsonToDTO<List<AtestadoDTO>>(response);
        }
    }
}
