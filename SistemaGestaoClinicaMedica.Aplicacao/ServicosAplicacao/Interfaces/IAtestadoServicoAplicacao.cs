using SistemaGestaoClinicaMedica.Aplicacao.DTOS.Atestado;
using System;

namespace SistemaGestaoClinicaMedica.Aplicacao.ServicosAplicacao
{
    public interface IAtestadoServicoAplicacao : IServicoAplicacaoBase<AtestadoSaidaDTO, AtestadoEntradaDTO, Guid>
    {
    }
}
