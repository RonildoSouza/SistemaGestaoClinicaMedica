using SistemaGestaoClinicaMedica.Aplicacao.DTO;
using System;
using System.Collections.Generic;

namespace SistemaGestaoClinicaMedica.Aplicacao.ServicosAplicacao
{
    public interface IAtestadoServicoAplicacao : IServicoAplicacaoBase<AtestadoDTO, Guid>
    {
        IList<AtestadoDTO> ObterTudoPorConsultaId(Guid consultaId);
    }
}
