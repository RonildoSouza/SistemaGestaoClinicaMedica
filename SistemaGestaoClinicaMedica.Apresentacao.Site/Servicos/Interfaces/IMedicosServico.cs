using SistemaGestaoClinicaMedica.Aplicacao.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaGestaoClinicaMedica.Apresentacao.Site.Servicos
{
    public interface IMedicosServico : IServicoLeituraBase<MedicoDTO, Guid>
    {
        Task<List<MedicoDTO>> GetPorEspecialidadeAsync(Guid especialidadeId);
    }
}
