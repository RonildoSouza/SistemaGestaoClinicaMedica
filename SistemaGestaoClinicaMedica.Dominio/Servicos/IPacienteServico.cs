using SistemaGestaoClinicaMedica.Dominio.Entidades;
using System;
using System.Collections.Generic;

namespace SistemaGestaoClinicaMedica.Dominio.Servicos
{
    public interface IPacienteServico : IServicoBase<Guid, Paciente>
    {
        Paciente ObterPorCodigoOuCPF(string codigoOuCpf);
        IList<Paciente> ObterTudoComFiltros(string busca, bool ativo);
    }
}
