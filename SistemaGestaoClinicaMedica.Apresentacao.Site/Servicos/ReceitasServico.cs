using SistemaGestaoClinicaMedica.Aplicacao.DTO;
using System;
using System.Threading.Tasks;

namespace SistemaGestaoClinicaMedica.Apresentacao.Site.Servicos
{
    public class ReceitasServico : ServicoBase<ReceitaDTO, Guid>, IReceitasServico
    {
        public ReceitasServico(ApplicationState applicationState) : base(applicationState) { }

        public async Task<ReceitaDTO> GetPorConsultaAsync(Guid consultaId)
        {
            var response = await ApplicationState.HttpClient.GetStringAsync($"{ApiEndPoint}/por-consulta/{consultaId}");
            return JsonToDTO<ReceitaDTO>(response);
        }
    }
}
