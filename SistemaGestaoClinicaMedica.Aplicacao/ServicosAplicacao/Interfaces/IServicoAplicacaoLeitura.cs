using System.Collections.Generic;

namespace SistemaGestaoClinicaMedica.Aplicacao.ServicosAplicacao
{
    public interface IServicoAplicacaoLeitura<TSaidaDTO, TEntidadeId>
    {
        TSaidaDTO Obter(TEntidadeId id);
        IList<TSaidaDTO> ObterTudo();
    }
}
