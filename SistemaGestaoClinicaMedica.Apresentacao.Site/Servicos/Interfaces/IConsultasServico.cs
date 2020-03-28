using SistemaGestaoClinicaMedica.Aplicacao.DTO;
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
    }
}
