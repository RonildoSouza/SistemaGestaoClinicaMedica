using SistemaGestaoClinicaMedica.Aplicacao.DTOS.Exame;
using System;

namespace SistemaGestaoClinicaMedica.Aplicacao.ServicosAplicacao
{
    public interface ITipoDeExameServicoAplicacao : IServicoAplicacaoLeitura<TipoDeExameSaidaDTO, Guid>
    {
    }
}
