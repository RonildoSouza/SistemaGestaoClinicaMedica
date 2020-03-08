using SistemaGestaoClinicaMedica.Dominio.Entidades;
using SistemaGestaoClinicaMedica.Dominio.Servicos;

namespace SistemaGestaoClinicaMedica.Infra.Data.Servicos
{
    public sealed class StatusConsultaServico : ServicoBase<EStatusConsulta, StatusConsulta>, IStatusConsultaServico
    {
        public StatusConsultaServico(ContextoBancoDados contextoBancoDados) : base(contextoBancoDados)
        {
        }
    }
}
