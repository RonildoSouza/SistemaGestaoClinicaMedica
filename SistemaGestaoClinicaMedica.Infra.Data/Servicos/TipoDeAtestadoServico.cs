using SistemaGestaoClinicaMedica.Dominio.Entidades;
using SistemaGestaoClinicaMedica.Dominio.Servicos;

namespace SistemaGestaoClinicaMedica.Infra.Data.Servicos
{
    public sealed class TipoDeAtestadoServico : ServicoBase<ETipoDeAtestado, TipoDeAtestado>, ITipoDeAtestadoServico
    {
        public TipoDeAtestadoServico(ContextoBancoDados contextoBancoDados) : base(contextoBancoDados)
        {
        }
    }
}
