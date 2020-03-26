using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using SistemaGestaoClinicaMedica.Aplicacao.DTO;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestaoClinicaMedica.Apresentacao.Site.Servicos
{
    public class ConsultaServico : ServicoBase<ConsultaDTO, Guid>, IConsultaServico
    {
        protected override string EndPoint => "consultas";

        public ConsultaServico(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<List<ConsultaDTO>> GetTudoComFiltrosAsync(DateTime dataInicio, DateTime dataFim, string busca, string status, Guid? medicoId = null)
        {
            var endpoint = $"{RequestUri}/?dataInicio={dataInicio.ToString("yyyy-MM-dd")}&dataFim={dataFim.ToString("yyyy-MM-dd")}&busca={busca}&status={status}";

            if (medicoId.HasValue && medicoId != Guid.Empty)
                endpoint += $"&medicoId={medicoId.Value}";

            var response = await HttpClient.GetStringAsync(endpoint);

            return JsonToDTO<List<ConsultaDTO>>(response);
        }

        public async Task<HttpResponseMessage> PutAlterarStatusAsync(Guid id, string statusConsultaId)
        {
            var jsonString = JsonConvert.SerializeObject(new StatusConsultaDTO { Id = statusConsultaId });
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            var response = await HttpClient.PutAsync($"{RequestUri}/alterar-status/{id}", content);
            return response;
        }
    }
}
