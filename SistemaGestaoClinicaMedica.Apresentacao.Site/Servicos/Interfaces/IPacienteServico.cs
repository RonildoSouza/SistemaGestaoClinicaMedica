using SistemaGestaoClinicaMedica.Aplicacao.DTO;
using System;
using System.Threading.Tasks;

namespace SistemaGestaoClinicaMedica.Apresentacao.Site.Servicos
{
    public interface IPacienteServico : IServicoBase<PacienteDTO, Guid>
    {
        Task<PacienteDTO> GetPorCodigoAsync(string pacienteCodigo);
    }
}
