using SistemaGestaoClinicaMedica.Aplicacao.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaGestaoClinicaMedica.Apresentacao.Site.Servicos
{
    public interface IEspecialidadesServico : IServicoLeituraBase<EspecialidadeDTO, Guid>
    {
        Task<List<EspecialidadeDTO>> GetDisponiveisAsync();
        Task<List<TimeSpan>> GetHorariosDisponiveisAsync(Guid especialidadeId, DateTime dataDaConsulta, Guid? medicoId);
        Task<Dictionary<DateTime, bool>> GetObterDatasComHorariosDisponiveisAsync(Guid especialidadeId, DateTime dataInicio, DateTime dataFim, Guid? medicoId);
    }
}
