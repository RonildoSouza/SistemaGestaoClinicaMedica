using SistemaGestaoClinicaMedica.Aplicacao.DTOS.Paciente;
using System;
using System.Collections.Generic;

namespace SistemaGestaoClinicaMedica.Aplicacao.ServicosAplicacao
{
    public interface IPacienteServicoAplicacao : IServicoAplicacaoBase<PacienteSaidaDTO, PacienteEntradaDTO, Guid>
    {
        IList<PacienteSaidaDTO> ObterTudo(string busca, bool ativo);
    }
}
