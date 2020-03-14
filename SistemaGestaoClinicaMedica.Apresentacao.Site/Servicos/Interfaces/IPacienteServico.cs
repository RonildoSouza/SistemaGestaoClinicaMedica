using SistemaGestaoClinicaMedica.Aplicacao.DTOS.Paciente;
using System;

namespace SistemaGestaoClinicaMedica.Apresentacao.Site.Servicos
{
    public interface IPacienteServico : IServicoBase<Guid, PacienteSaidaDTO, PacienteEntradaDTO>
    {
    }
}
