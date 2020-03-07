using SistemaGestaoClinicaMedica.Dominio.Entidades;
using System;
using System.Collections.Generic;

namespace SistemaGestaoClinicaMedica.Dominio.Servicos
{
    public interface IPacienteServico : IServicoBase<Guid, Paciente>
    {
        IList<Paciente> ObterTudo(string busca, bool ativo);
    }
}
