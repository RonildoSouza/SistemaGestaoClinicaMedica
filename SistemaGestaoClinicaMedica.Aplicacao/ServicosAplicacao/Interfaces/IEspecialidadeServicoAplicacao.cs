using SistemaGestaoClinicaMedica.Aplicacao.DTOS.Especialidade;
using System;
using System.Collections.Generic;

namespace SistemaGestaoClinicaMedica.Aplicacao.ServicosAplicacao
{
    public interface IEspecialidadeServicoAplicacao : IServicoAplicacaoLeitura<EspecialidadeSaidaDTO, Guid>
    {
        IList<EspecialidadeSaidaDTO> ObterTudo(bool comMedicos = false);
    }
}
