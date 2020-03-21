using SistemaGestaoClinicaMedica.Dominio.Entidades;
using System;

namespace SistemaGestaoClinicaMedica.Dominio.Servicos
{
    public interface IReceitaServico : IServicoBase<Guid, Receita>
    {
        Receita ObterPorConsultaId(Guid consultaId);
    }
}
