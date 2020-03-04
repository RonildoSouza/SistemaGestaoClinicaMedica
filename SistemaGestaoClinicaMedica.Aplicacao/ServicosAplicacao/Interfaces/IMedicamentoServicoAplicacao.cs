using SistemaGestaoClinicaMedica.Aplicacao.DTOS.Medicamento;
using System;
using System.Collections.Generic;

namespace SistemaGestaoClinicaMedica.Aplicacao.ServicosAplicacao
{
    public interface IMedicamentoServicoAplicacao
    {
        MedicamentoSaidaDTO Salvar(MedicamentoEntradaDTO medicamentoEntradaDTO, Guid id = default);
        MedicamentoSaidaDTO Obter(Guid id);
        IList<MedicamentoSaidaDTO> ObterTudo(string nome, bool ativo = true);
        void Deletar(Guid id);
    }
}
