using SistemaGestaoClinicaMedica.Aplicacao.DTOS.Exame;
using System;

namespace SistemaGestaoClinicaMedica.Aplicacao.ServicosAplicacao
{
    public interface IExameServicoAplicacao : IServicoAplicacaoBase<ExameSaidaDTO, ExameEntradaDTO, Guid>
    {
        ExameSaidaDTO Obter(string codigo);
        void UploadResultado(Guid id, ArquivoResultadoExameEntradaDTO arquivoDTO);
    }
}
