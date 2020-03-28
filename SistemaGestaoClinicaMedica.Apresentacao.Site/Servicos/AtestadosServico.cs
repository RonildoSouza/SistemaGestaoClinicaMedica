using Microsoft.Extensions.Configuration;
using SistemaGestaoClinicaMedica.Aplicacao.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaGestaoClinicaMedica.Apresentacao.Site.Servicos
{
    public class AtestadosServico : ServicoBase<AtestadoDTO, Guid>, IAtestadosServico
    {
        public AtestadosServico(IConfiguration configuration) : base(configuration) { }

        public async Task<List<AtestadoDTO>> GetPorConsultaAsync(Guid consultaId)
        {
            var response = await HttpClient.GetStringAsync($"{RequestUri}/por-consulta/{consultaId}");
            return JsonToDTO<List<AtestadoDTO>>(response);
        }
    }
}
