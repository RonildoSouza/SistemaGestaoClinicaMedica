using SistemaGestaoClinicaMedica.Aplicacao.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaGestaoClinicaMedica.Apresentacao.Site.Servicos
{
    public class EspecialidadesServico : ServicoBaseLeitura<EspecialidadeDTO, Guid>, IEspecialidadesServico
    {
        public EspecialidadesServico(ApplicationState applicationState) : base(applicationState) { }

        public async Task<List<EspecialidadeDTO>> GetDisponiveisAsync()
        {
            var response = await ApplicationState.HttpClient.GetStringAsync($"{ApiEndPoint}/disponiveis");
            return JsonToDTO<List<EspecialidadeDTO>>(response);
        }

        public async Task<List<TimeSpan>> GetHorariosDisponiveisAsync(Guid especialidadeId, DateTime dataDaConsulta, Guid? medicoId)
        {
            var endpoint = $"{ApiEndPoint}/{especialidadeId}/horarios-disponiveis/{dataDaConsulta.ToString("yyyy-MM-dd")}";
            endpoint = medicoId.HasValue ? $"{endpoint}/{medicoId}" : endpoint;
            var response = await ApplicationState.HttpClient.GetStringAsync(endpoint);

            return JsonToDTO<List<TimeSpan>>(response);
        }

        public async Task<Dictionary<DateTime, bool>> GetObterDatasComHorariosDisponiveisAsync(Guid especialidadeId, DateTime dataInicio, DateTime dataFim, Guid? medicoId)
        {
            var endpoint = $"{ApiEndPoint}/{especialidadeId}/datas-com-horarios-disponiveis/{dataInicio.ToString("yyyy-MM-dd")}/{dataFim.ToString("yyyy-MM-dd")}";
            endpoint = medicoId.HasValue ? $"{endpoint}/{medicoId}" : endpoint;
            var response = await ApplicationState.HttpClient.GetStringAsync(endpoint);

            return JsonToDTO<Dictionary<DateTime, bool>>(response);
        }
    }
}
