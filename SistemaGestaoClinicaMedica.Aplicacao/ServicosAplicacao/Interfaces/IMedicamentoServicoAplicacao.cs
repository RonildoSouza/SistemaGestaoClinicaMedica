using SistemaGestaoClinicaMedica.Aplicacao.DTOS.Medicamento;
using System;
using System.Collections.Generic;

namespace SistemaGestaoClinicaMedica.Aplicacao.ServicosAplicacao
{
    public interface IMedicamentoServicoAplicacao : IServicoAplicacaoBase<MedicamentoSaidaDTO, MedicamentoEntradaDTO, Guid>
    {
        IList<MedicamentoSaidaDTO> ObterTudo(string nome, bool ativo = true);
    }
}
