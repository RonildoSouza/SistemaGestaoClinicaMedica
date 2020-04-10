using SistemaGestaoClinicaMedica.Aplicacao.DTO;
using System;
using System.Collections.Generic;

namespace SistemaGestaoClinicaMedica.Aplicacao.ServicosAplicacao
{
    public interface IMedicoServicoAplicacao : IServicoAplicacaoBase<MedicoDTO, Guid>
    {
        IList<MedicoDTO> ObterTudoPorEspecialidade(Guid especialidadeId);
        MedicoDTO ObterPorCRM(string crm);
    }
}
