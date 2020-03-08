using SistemaGestaoClinicaMedica.Dominio.Entidades;
using SistemaGestaoClinicaMedica.Dominio.Servicos;
using System;
using System.Linq;

namespace SistemaGestaoClinicaMedica.Infra.Data.Servicos
{
    public sealed class LaboratorioServico : ServicoBase<Guid, Laboratorio>, ILaboratorioServico
    {
        public LaboratorioServico(ContextoBancoDados contextoBancoDados) : base(contextoBancoDados)
        {
        }

        public override Laboratorio Obter(Guid id)
        {
            return Entidades.SingleOrDefault(_ => _.Id == id || _.Funcionario.Id == id);
        }
    }
}
