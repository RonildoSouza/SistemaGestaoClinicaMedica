using System.Collections.Generic;

namespace SistemaGestaoClinicaMedica.Aplicacao.ServicosAplicacao
{
    public interface IServicoAplicacaoLeitura<TSaidaDTO, TId>
    {
        TSaidaDTO Obter(TId id);
        IList<TSaidaDTO> ObterTudo();
    }
}
