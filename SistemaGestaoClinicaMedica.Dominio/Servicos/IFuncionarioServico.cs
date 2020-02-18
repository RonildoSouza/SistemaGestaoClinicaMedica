using SistemaGestaoClinicaMedica.Dominio.Entidades;
using System;

namespace SistemaGestaoClinicaMedica.Dominio.Servicos
{
    public interface IFuncionarioServico : IServicoBase<Guid, Funcionario>
    {
        Funcionario Autorizar(string email, string senha);
    }
}
