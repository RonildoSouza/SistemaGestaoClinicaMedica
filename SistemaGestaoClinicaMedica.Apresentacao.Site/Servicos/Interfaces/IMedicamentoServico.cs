using SistemaGestaoClinicaMedica.Aplicacao.DTOS.Medicamento;
using System;

namespace SistemaGestaoClinicaMedica.Apresentacao.Site.Servicos
{
    public interface IMedicamentoServico : IServicoBase<Guid, MedicamentoSaidaDTO, MedicamentoEntradaDTO>
    {
    }
}
