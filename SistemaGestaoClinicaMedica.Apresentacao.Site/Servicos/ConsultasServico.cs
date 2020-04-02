using Newtonsoft.Json;
using SistemaGestaoClinicaMedica.Aplicacao.DTO;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestaoClinicaMedica.Apresentacao.Site.Servicos
{
    public class ConsultasServico : ServicoBase<ConsultaDTO, Guid>, IConsultasServico
    {
        public ConsultasServico(ApplicationState applicationState) : base(applicationState) { }

        public async Task<ConsultaDTO> GetPorCodigoAsync(string codigo)
        {
            var response = await ApplicationState.HttpClient.GetStringAsync($"{ApiEndPoint}/por-codigo/{codigo}");
            return JsonToDTO<ConsultaDTO>(response);
        }

        public async Task<List<ConsultaDTO>> GetTudoComFiltrosAsync(DateTime dataInicio, DateTime dataFim, string busca, string status, Guid? medicoId = null)
        {
            var endpoint = $"{ApiEndPoint}/?dataInicio={dataInicio.ToString("yyyy-MM-dd")}&dataFim={dataFim.ToString("yyyy-MM-dd")}&busca={busca}&status={status}";

            if (medicoId.HasValue && medicoId != Guid.Empty)
                endpoint += $"&medicoId={medicoId.Value}";

            var response = await ApplicationState.HttpClient.GetStringAsync(endpoint);

            return JsonToDTO<List<ConsultaDTO>>(response);
        }

        public async Task<HttpResponseMessage> PutAlterarStatusAsync(Guid id, string statusConsultaId)
        {
            var jsonString = JsonConvert.SerializeObject(new StatusConsultaDTO { Id = statusConsultaId });
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            var response = await ApplicationState.HttpClient.PutAsync($"{ApiEndPoint}/alterar-status/{id}", content);
            return response;
        }
    }
}
