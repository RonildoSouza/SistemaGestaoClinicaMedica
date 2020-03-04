using SistemaGestaoClinicaMedica.Dominio.Entidades;
using System;
using System.Linq;

namespace SistemaGestaoClinicaMedica.Dominio.Servicos
{
    public interface IMedicamentoServico : IServicoBase<Guid, Medicamento>
    {
        IQueryable<Medicamento> ObterTudo(string nome, bool ativo = true);
    }
}
