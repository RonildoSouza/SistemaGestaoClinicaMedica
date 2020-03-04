using SistemaGestaoClinicaMedica.Aplicacao.DTOS.Especialidade;
using System;
using System.Collections.Generic;

namespace SistemaGestaoClinicaMedica.Aplicacao.ServicosAplicacao
{
    public interface IEspecialidadeServicoAplicacao
    {
        EspecialidadeSaidaDTO Obter(Guid id);
        IList<EspecialidadeSaidaDTO> ObterTudo(bool comMedicos = false);
    }
}
