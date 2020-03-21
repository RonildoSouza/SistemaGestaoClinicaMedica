using SistemaGestaoClinicaMedica.Dominio.Entidades;
using System;
using System.Collections.Generic;

namespace SistemaGestaoClinicaMedica.Dominio.Servicos
{
    public interface IFuncionarioServico : IServicoBase<Guid, Funcionario>
    {
        Funcionario Autorizar(string email, string senha);
        IList<Funcionario> ObterTudoComFiltros(bool ativo);
    }
}
