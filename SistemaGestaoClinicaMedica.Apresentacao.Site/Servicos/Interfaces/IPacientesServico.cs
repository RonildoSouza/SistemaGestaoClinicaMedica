using SistemaGestaoClinicaMedica.Aplicacao.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaGestaoClinicaMedica.Apresentacao.Site.Servicos
{
    public interface IPacientesServico : IServicoBase<PacienteDTO, Guid>
    {
        Task<PacienteDTO> GetPorCodigoOuCPFAsync(string codigoOuCpf);
        Task<List<PacienteDTO>> GetTudoComFiltrosAsync(string busca, bool ativo = true);
    }
}
