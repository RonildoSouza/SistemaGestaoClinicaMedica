using Microsoft.Extensions.Configuration;
using SistemaGestaoClinicaMedica.Aplicacao.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaGestaoClinicaMedica.Apresentacao.Site.Servicos
{
    public class ConsultaServico : ServicoBase<ConsultaDTO, Guid>, IConsultaServico
    {
        protected override string EndPoint => "consultas";

        public ConsultaServico(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<List<ConsultaDTO>> GetTudoComFiltrosAsync(DateTime dataInicio, DateTime dataFim, string busca, string status)
        {
            var endpoint = $"{RequestUri}/?dataInicio={dataInicio.ToString("yyyy-MM-dd")}&dataFim={dataFim.ToString("yyyy-MM-dd")}&busca={busca}&status={status}";
            var response = await HttpClient.GetStringAsync(endpoint);

            return JsonToDTO<List<ConsultaDTO>>(response);
        }
    }
}
