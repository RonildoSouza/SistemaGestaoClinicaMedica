using SistemaGestaoClinicaMedica.Dominio.Entidades;
using SistemaGestaoClinicaMedica.Dominio.Servicos;

namespace SistemaGestaoClinicaMedica.Infra.Data.Servicos
{
    public sealed class StatusExameServico : ServicoBase<EStatusExame, StatusExame>, IStatusExameServico
    {
        public StatusExameServico(ContextoBancoDados contextoBancoDados) : base(contextoBancoDados)
        {
        }
    }
}
