using SistemaGestaoClinicaMedica.Aplicacao.DTO;
using System;
using System.Threading.Tasks;

namespace SistemaGestaoClinicaMedica.Apresentacao.Site.Servicos
{
    public interface IPacientesServico : IServicoBase<PacienteDTO, Guid>
    {
        Task<PacienteDTO> GetPorCodigoAsync(string pacienteCodigo);
    }
}
