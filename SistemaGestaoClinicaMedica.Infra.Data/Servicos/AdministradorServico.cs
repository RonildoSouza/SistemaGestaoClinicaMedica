using SistemaGestaoClinicaMedica.Dominio.Entidades;
using SistemaGestaoClinicaMedica.Dominio.Servicos;
using System;

namespace SistemaGestaoClinicaMedica.Infra.Data.Servicos
{
    public sealed class AdministradorServico : ServicoBase<Guid, Administrador>, IAdministradorServico
    {
        public AdministradorServico(ContextoBancoDados contextoBancoDados) : base(contextoBancoDados)
        {
        }
    }
}
