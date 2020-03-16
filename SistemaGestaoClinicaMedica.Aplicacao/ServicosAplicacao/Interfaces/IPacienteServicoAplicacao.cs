using SistemaGestaoClinicaMedica.Aplicacao.DTO;
using System;
using System.Collections.Generic;

namespace SistemaGestaoClinicaMedica.Aplicacao.ServicosAplicacao
{
    public interface IPacienteServicoAplicacao : IServicoAplicacaoBase<PacienteDTO, Guid>
    {
        IList<PacienteDTO> ObterTudo(string busca, bool ativo);
    }
}
