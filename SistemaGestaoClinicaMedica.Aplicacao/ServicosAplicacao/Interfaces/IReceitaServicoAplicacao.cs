using SistemaGestaoClinicaMedica.Aplicacao.DTOS.Receita;
using System;

namespace SistemaGestaoClinicaMedica.Aplicacao.ServicosAplicacao
{
    public interface IReceitaServicoAplicacao : IServicoAplicacaoBase<ReceitaSaidaDTO, ReceitaEntradaDTO, Guid>
    {
        ReceitaSaidaDTO ObterPorConsultaId(Guid id);
    }
}
