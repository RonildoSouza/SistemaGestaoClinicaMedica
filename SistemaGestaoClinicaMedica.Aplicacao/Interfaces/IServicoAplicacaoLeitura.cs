using System.Collections.Generic;

namespace SistemaGestaoClinicaMedica.Aplicacao.ServicosAplicacao
{
    public interface IServicoAplicacaoLeitura<TDTO, TEntidadeId>
    {
        TDTO Obter(TEntidadeId id);
        IList<TDTO> ObterTudo();
    }
}
