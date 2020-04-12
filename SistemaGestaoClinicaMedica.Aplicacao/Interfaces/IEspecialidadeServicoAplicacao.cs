using SistemaGestaoClinicaMedica.Aplicacao.DTO;
using System;
using System.Collections.Generic;

namespace SistemaGestaoClinicaMedica.Aplicacao.ServicosAplicacao
{
    public interface IEspecialidadeServicoAplicacao : IServicoAplicacaoLeitura<EspecialidadeDTO, Guid>
    {
        IList<EspecialidadeDTO> ObterDisponiveis();
        IList<EspecialidadeDTO> ObterTudo(bool comMedicos);
        IList<TimeSpan> ObterHorariosDisponiveis(Guid especialidadeId, DateTime dataDaConsulta, Guid? medicoId = null);
    }
}
