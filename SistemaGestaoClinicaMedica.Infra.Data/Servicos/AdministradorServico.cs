using SistemaGestaoClinicaMedica.Dominio.Entidades;
using SistemaGestaoClinicaMedica.Dominio.Servicos;
using System;
using System.Linq;

namespace SistemaGestaoClinicaMedica.Infra.Data.Servicos
{
    public sealed class AdministradorServico : ServicoBase<Guid, Administrador>, IAdministradorServico
    {
        public AdministradorServico(ContextoBancoDados contextoBancoDados) : base(contextoBancoDados)
        {
        }

        public override Administrador Obter(Guid id)
        {
            return Entidades.SingleOrDefault(_ => _.Id == id || _.Funcionario.Id == id);
        }
    }
}
