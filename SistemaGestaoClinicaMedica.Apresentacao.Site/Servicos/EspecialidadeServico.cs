using Microsoft.Extensions.Configuration;
using SistemaGestaoClinicaMedica.Aplicacao.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaGestaoClinicaMedica.Apresentacao.Site.Servicos
{
    public class EspecialidadeServico : ServicoBaseLeitura<EspecialidadeDTO, Guid>, IEspecialidadeServico
    {
        protected override string EndPoint => "especialidades";

        public EspecialidadeServico(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<List<EspecialidadeDTO>> GetDisponiveisAsync()
        {
            var response = await HttpClient.GetStringAsync($"{RequestUri}/disponiveis");
            return JsonToDTO<List<EspecialidadeDTO>>(response);
        }

        public async Task<List<TimeSpan>> GetHorariosDisponiveisAsync(Guid especialidadeId, DateTime dataDaConsulta, Guid? medicoId)
        {
            var endpoint = $"{RequestUri}/{especialidadeId}/horarios-disponiveis/{dataDaConsulta.ToString("yyyy-MM-dd")}";
            endpoint = medicoId.HasValue ? $"{endpoint}/{medicoId}" : endpoint;
            var response = await HttpClient.GetStringAsync(endpoint);

            return JsonToDTO<List<TimeSpan>>(response);
        }
    }
}
