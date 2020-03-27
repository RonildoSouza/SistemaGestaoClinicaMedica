using SistemaGestaoClinicaMedica.Aplicacao.DTO;
using System;
using System.Collections.Generic;

namespace SistemaGestaoClinicaMedica.Aplicacao.ServicosAplicacao
{
    public interface IMedicamentoServicoAplicacao : IServicoAplicacaoBase<MedicamentoDTO, Guid>
    {
        IList<MedicamentoDTO> ObterTudoPorNome(string nome);
        IList<MedicamentoDTO> ObterTudo(string busca, bool ativo);
    }
}
