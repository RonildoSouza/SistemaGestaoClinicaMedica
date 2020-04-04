using SistemaGestaoClinicaMedica.Aplicacao.DTO;
using SistemaGestaoClinicaMedica.Apresentacao.Site.Modelos;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace SistemaGestaoClinicaMedica.Apresentacao.Site.Servicos
{
    public interface IConsultasServico : IServicoBase<ConsultaDTO, Guid>
    {
        Task<List<ConsultaDTO>> GetTudoComFiltrosAsync(DateTime dataInicio, DateTime dataFim, string busca, string status, Guid? medicoId = null);
        Task<HttpResponseMessage> PutAlterarStatusAsync(Guid id, string statusConsultaId);
        Task<ConsultaDTO> GetPorCodigoAsync(string codigo);
        Task<ChartJSDataset> GetTotalConsultasPorEspecialidadeAsync(DateTime dataInicio, DateTime dataFim);
        Task<ChartJSDataset> GetTotalConsultasPorMesAsync(DateTime dataInicio, DateTime dataFim);
        Task<ChartJSDataset> GetTotalConsultasPorSexoPacienteAsync(DateTime dataInicio, DateTime dataFim);
        Task<ChartJSDataset> GetTotalConsultasPorIdadePacienteAsync(DateTime dataInicio, DateTime dataFim);
    }
}
