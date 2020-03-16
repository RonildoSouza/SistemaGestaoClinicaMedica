using SistemaGestaoClinicaMedica.Aplicacao.DTO;
using System;

namespace SistemaGestaoClinicaMedica.Aplicacao.ServicosAplicacao
{
    public interface IExameServicoAplicacao : IServicoAplicacaoBase<ExameDTO, Guid>
    {
        ExameDTO Obter(string codigo);
        void UploadResultado(Guid id, ArquivoResultadoExameDTO arquivoDTO);
    }
}
