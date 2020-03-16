using SistemaGestaoClinicaMedica.Aplicacao.DTO;
using System;

namespace SistemaGestaoClinicaMedica.Aplicacao.ServicosAplicacao
{
    public interface IReceitaServicoAplicacao : IServicoAplicacaoBase<ReceitaDTO, Guid>
    {
        ReceitaDTO ObterPorConsultaId(Guid id);
    }
}
