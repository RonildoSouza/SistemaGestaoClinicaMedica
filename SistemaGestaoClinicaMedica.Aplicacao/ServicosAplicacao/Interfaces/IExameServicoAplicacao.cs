using SistemaGestaoClinicaMedica.Aplicacao.DTO;
using System;
using System.Collections.Generic;

namespace SistemaGestaoClinicaMedica.Aplicacao.ServicosAplicacao
{
    public interface IExameServicoAplicacao : IServicoAplicacaoBase<ExameDTO, Guid>
    {
        ExameDTO Obter(string codigo);
        Uri UploadResultado(Guid id, ArquivoResultadoExameDTO arquivoDTO);
        void AlterarStatus(Guid id, StatusExameDTO statusExame);
        IList<ExameDTO> ObterTudoPorConsultaId(Guid consultaId);
        IList<ExameDTO> ObterTudoComFiltro(string busca);
    }
}
